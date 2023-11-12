using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TagTool.Common
{
	//note: this thread pool doesn't ever free allocated threads, unless FreeAllThreads is called
    public static class CustomThreadPool
    {
		private static List<ThreadState> availableList = new();
		private static readonly object availableListLocker = new();

		private class ThreadState
		{
			public Thread Thread;
			public SemaphoreSlim FinishedSemaphore;
			public SemaphoreSlim RequeueSemaphore;
			public object State;
			public object Result;
			public Exception Exception;
			public Func<object, object> Code;
			public bool ShouldExit;
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
			state.RequeueSemaphore = new SemaphoreSlim(0, 1);
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

					//check if we should exit quickly
					if (state.ShouldExit) return;

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

					//check if we should re-queue automatically
					if (state.RequeueSemaphore.Wait(0))
					{
						//do the actual auto requeuing
						Release(state);
					}
					else
					{
						//inform the caller we've finished
						state.FinishedSemaphore.Release(1);

						//double check we didn't miss an auto-requeue event
						if (state.RequeueSemaphore.Wait(0))
						{
							//take the finish semaphore back
							state.FinishedSemaphore.Wait();

							//do the actual auto requeuing
							Release(state);
						}
					}
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

		public interface IScheduledTask
		{
			void Wait();
			object Result { get; }
		}

		private sealed class ScheduledTask : IScheduledTask
		{
			public ThreadState threadState;
			private object result;
			private Exception exception;

			public void Wait()
			{
				//wait until we finish (this synchronises the assignment to Exception and Result inside of the running thread)
				threadState.FinishedSemaphore.Wait();

				//read the exception and result
				(exception, result) = (threadState.Exception, threadState.Result);

				//release the thread state, so it can be used again in the future
				Release(threadState);

				//skip finalisation of this object & release resources
				threadState = null;
				GC.SuppressFinalize(this);
			}

			~ScheduledTask()
			{
				//if it's already done, we can just release it now
				if (threadState.FinishedSemaphore.Wait(0))
				{
					Release(threadState);
				}
				else
				{
					//otherwise, tell it to auto-requeue itself
					threadState.RequeueSemaphore.Release(1);
				}
			}

			public object Result
			{
				get
				{
					//ensure we've called Wait
					if (threadState != null) Wait();

					//return the result, or throw the error (wrapped so we don't lose the stack trace)
					if (exception != null) throw new AggregateException(exception);
					else return result;
				}
			}
		}

		public static IScheduledTask Schedule(object state, Func<object, object> code)
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

			//return a scheduled task
			return new ScheduledTask() { threadState = threadState };
		}

		public static void FreeAllThreads()
		{
			lock (availableListLocker)
			{
				foreach (var thread in availableList)
				{
					//inform it that it should exit
					thread.ShouldExit = true;

					//interrupt it to get it to exit
					thread.Thread.Interrupt();
				}

				//clear the available list
				availableList.Clear();
			}
		}
    }
}
