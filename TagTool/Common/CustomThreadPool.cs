using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TagTool.Common
{
    public static class CustomThreadPool
    {
		private static List<ThreadState> availableList = new();
		private static readonly object availableListLocker = new();

		private class ThreadState
		{
			public Thread Thread;
			public SemaphoreSlim FinishedSemaphore;
			public object State;
			public object Result;
			public Exception Exception;
			public Func<object, object> Code;
		}

		private static ThreadState Acquire()
		{
			//try to get an existing one if possible
			lock (availableListLocker)
			{
				if (availableList.Count > 0)
				{
					var result = availableList[availableList.Count - 1];
					availableList.RemoveAt(availableList.Count - 1);
					return result;
				}
			}

			//otherwise, create a new one
			ThreadState state = new();
			state.FinishedSemaphore = new SemaphoreSlim(0, 1);
			state.Thread = new Thread(static (s) =>
			{
				ThreadState state = (ThreadState)s;
				while (true)
				{
					//wait until interrupted
					try
					{
						Thread.Sleep(Timeout.Infinite);
					}
					catch (ThreadInterruptedException) { }

					//run a task
					try
					{
						state.Result = state.Code(state.State);
						state.Exception = null;
					}
					catch (Exception ex)
					{
						state.Exception = ex;
						state.Result = null;
					}

					//inform the caller
					state.FinishedSemaphore.Release(1);
				}
			});
			state.Thread.Priority = ThreadPriority.AboveNormal;
			state.Thread.Start();
			return state;
		}

		private static void Release(ThreadState state)
		{
			//try to get an existing one if possible
			lock (availableListLocker)
			{
				availableList.Add(state);
			}
		}

		public async static Task<object> Schedule(object state, Func<object, object> code)
		{
			//acquire a thread to run this on
			var threadState = Acquire();

			//setup the thread state
			threadState.State = state;
			threadState.Result = null;
			threadState.Exception = null;
			threadState.Code = code;

			//start the thread (this synchronises the prior assignments also)
			threadState.Thread.Interrupt();

			//wait until we finish (this synchronises the assignment to Exception and Result inside of the running thread)
			await threadState.FinishedSemaphore.WaitAsync();

			//read the exception and result
			var (exception, result) = (threadState.Exception, threadState.Result);

			//release the thread state, so it can be used again in the future
			Release(threadState);

			//return the result, or throw the error (wrapped so we don't lose the stack trace)
			if (exception != null) throw new AggregateException(exception);
			else return result;
		}
    }
}
