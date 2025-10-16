using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TagTool.Cache;

namespace TagTool.Porting
{
    public partial class PortingContext
    {
        private readonly SingleThreadTaskScheduler _mainThreadScheduler = new();
        private readonly SemaphoreSlim _concurrencyLimiter = new(Environment.ProcessorCount * 2);
        private readonly int _mainThreadId = Environment.CurrentManagedThreadId;
        private readonly Stack<List<Task>> _taskListStack = new();
        private readonly List<Task> _allTasks = [];
        private readonly Dictionary<int, Task> _tagConvertTasks = [];

        public int MainThreadId => _mainThreadId;

        /// <summary>
        /// Used to schedule tasks to execute on the main thread
        /// </summary>
        public TaskScheduler MainThreadScheduler => _mainThreadScheduler;


        /// <summary>
        /// Executes a function on the thread pool with limited concurrency.
        /// </summary>
        /// <remarks>
        /// This should be preferred over using Task.Run
        /// </remarks>
        public Task<T> RunOnThreadPool<T>(Func<T> func)
        {
            _concurrencyLimiter.Wait();

            return Task.Run(() =>
            {
                try
                {
                    return func();
                }
                finally
                {
                    _concurrencyLimiter.Release();
                }
            });
        }

        /// <summary>
        /// Executes an action on the thread pool with limited concurrency.
        /// </summary>
        /// <remarks>
        /// This should be preferred over Task.Run
        /// </remarks>
        public Task RunOnThreadPool(Action action)
        {
            _concurrencyLimiter.Wait();

            return Task.Run(() =>
            {
                try
                {
                    action();
                }
                finally
                {
                    _concurrencyLimiter.Release();
                }
            });
        }


        public void AddTask(Task task)
        {
            Debug.Assert(Environment.CurrentManagedThreadId == _mainThreadId);

            if (_taskListStack.Count > 0)
                _taskListStack.Peek().Add(task);
            else
                _allTasks.Add(task);
        }

        private void ProcessTasks()
        {
            _mainThreadScheduler.Poll(0);
            ProcessCompletedTasks();
        }

        private bool ProcessCompletedTasks()
        {
            for (int i = _allTasks.Count - 1; i >= 0; i--)
            {
                var task = _allTasks[i];
                if (task.IsCompleted)
                    _allTasks.RemoveAt(i);
            }

            return _allTasks.Count > 0;
        }

        private void FinishAsync()
        {
            Debug.Assert(Environment.CurrentManagedThreadId == _mainThreadId);

            try
            {
                while (ProcessCompletedTasks())
                {
                    _mainThreadScheduler.Poll(100);
                }
            }
            finally
            {
                _mainThreadScheduler.DiscardAll();
                _allTasks.Clear();
                _taskListStack.Clear();
                _tagConvertTasks.Clear();
            }
        }

        /// <summary>
        /// Waits for the tag to be serialized.
        /// </summary>
        /// <remarks>
        /// Only use this as a last resort. Instead use <see cref="WaitForTagAsync"/> with a continuation to avoid porting pipeline stalls.
        /// </remarks>
        public void WaitForTag(CachedTag tag)
        {
            Debug.Assert(Environment.CurrentManagedThreadId == _mainThreadId);

            if (_tagConvertTasks.TryGetValue(tag.Index, out Task task))
            {
                WaitForTaskBlocking(task);
            }
        }

        /// <summary>
        /// Returns a task that completes when the <paramref name="tag"/> has been serialized.
        /// </summary>
        public Task WaitForTagAsync(CachedTag tag)
        {
            Debug.Assert(Environment.CurrentManagedThreadId == _mainThreadId);

            if (tag == null)
                return Task.CompletedTask;

            if (_tagConvertTasks.TryGetValue(tag.Index, out Task task))
            {
                return task;
            }

            return Task.CompletedTask;
        }

        private bool WaitForTaskBlocking(Task task)
        {
            var stopwatch = Stopwatch.StartNew();
            while (!task.IsCompleted)
            {
                _mainThreadScheduler.Poll(100);
                ProcessCompletedTasks();
            }

            if(task.IsFaulted)
                task.GetAwaiter().GetResult();

            return true;
        }

        class SingleThreadTaskScheduler : TaskScheduler
        {
            private readonly BlockingCollection<Task> _taskQueue = [];
            private readonly int _threadID = -1;

            public SingleThreadTaskScheduler()
            {
                _threadID = Environment.CurrentManagedThreadId;
            }

            public int QueuedTaskCount => _taskQueue.Count;

            protected override IEnumerable<Task> GetScheduledTasks()
            {
                return [.. _taskQueue];
            }

            protected override void QueueTask(Task task)
            {
                if (!TryExecuteTaskInline(task, false))
                    _taskQueue.Add(task);
            }

            protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
            {
                if (taskWasPreviouslyQueued)
                    return false;

                // if we're on the main thread just execute it synchronously
                if (Environment.CurrentManagedThreadId == _threadID)
                    return TryExecuteTask(task);

                return false;
            }

            public void DiscardAll()
            {
                Debug.Assert(Environment.CurrentManagedThreadId == _threadID);

                while (_taskQueue.TryTake(out Task _)) { }
            }

            public void Poll(int timeoutMs)
            {
                var stopwatch = Stopwatch.StartNew();
                while (true)
                {
                    int remainingMs = timeoutMs == Timeout.Infinite
                        ? Timeout.Infinite
                        : Math.Max(0, timeoutMs - (int)stopwatch.ElapsedMilliseconds);

                    if (!_taskQueue.TryTake(out Task task, remainingMs))
                        break;

                    if (TryExecuteTask(task))
                    {
                        // catch exceptions early and rethrow
                        if (task.IsFaulted)
                            task.GetAwaiter().GetResult();
                    }
                }
            }
        }
    }
}
