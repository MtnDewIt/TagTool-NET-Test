using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace TagTool.Porting
{
    public partial class PortingContext
    {
        private AsyncTaskQueue AsyncQueue;

        private void InitAsync()
        {
            Debug.Assert(AsyncQueue == null, "Async task queue already initialized!");

            AsyncQueue = new AsyncTaskQueue(DeferredActions, Options.MaxThreads);
        }

        protected void WaitForPendingTasks()
        {
            AsyncQueue.WaitAllNoThrow();
            AsyncQueue.Clear();
        }

        public void RunAsync(Action onExecute, Action onSuccess)
        {
            Debug.Assert(AsyncQueue != null, "Async task queue not initialized!");

            AsyncQueue.RunAsync(onExecute, onSuccess);
        }

        public void RunAsync<T>(Func<T> onExecute, Action<T> onSuccess)
        {
            Debug.Assert(AsyncQueue != null, "Async task queue not initialized!");

            AsyncQueue.RunAsync(onExecute, onSuccess);
        }

        class AsyncTaskQueue
        {
            private readonly BlockingCollection<Action> _executor;
            private readonly SemaphoreSlim ConcurrencyLimiter;
            private readonly List<Task> Tasks = new List<Task>();

            public AsyncTaskQueue(BlockingCollection<Action> executor, int maxThreads)
            {
                _executor = executor;
                ConcurrencyLimiter = new SemaphoreSlim(maxThreads);
            }

            public void RunAsync(Action onExecute, Action onSuccess)
            {
                ConcurrencyLimiter.Wait();

                var task = Task.Run(() =>
                {
                    try
                    {
                        onExecute();
                        HandleSuccess(onSuccess);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                    finally
                    {
                        ConcurrencyLimiter.Release();
                    }
                });
                Tasks.Add(task);
            }

            public void RunAsync<T>(Func<T> onExecute, Action<T> onSuccess)
            {
                ConcurrencyLimiter.Wait();

                var task = Task.Run(() =>
                {
                    try
                    {
                        T result = onExecute();
                        HandleSuccess(() => onSuccess(result));
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                    finally
                    {
                        ConcurrencyLimiter.Release();
                    }
                });
                Tasks.Add(task);
            }

            public void Clear()
            {
                Tasks.Clear();
            }

            public void WaitAll()
            {
                Task.WhenAll(Tasks.ToArray()).GetAwaiter().GetResult();
            }

            public void WaitAllNoThrow()
            {
                try
                {
                    Task.WhenAll(Tasks.ToArray()).GetAwaiter().GetResult();
                }
                catch
                {
                    /* swallow */
                }
            }

            private void HandleSuccess(Action onSuccess)
            {
                _executor.Add(onSuccess);
            }

            private void HandleException(Exception ex)
            {
                var dispatchInfo = ExceptionDispatchInfo.Capture(ex);
                _executor.Add(() =>
                {
                    dispatchInfo.Throw();
                });
            }
        }
    }
}
