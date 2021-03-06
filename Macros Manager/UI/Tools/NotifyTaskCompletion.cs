﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Macros_Manager.UI.Tools
{
    public sealed class NotifyTaskCompletion<TResult> : BaseNotifyPropertyChanged
    {
        public NotifyTaskCompletion(Task<TResult> a_task)
        {
            Task = a_task;
            if (!a_task.IsCompleted)
            {
                var _ = WatchTaskAsync(a_task);
            }
        }

        public async Task WatchTaskAsync(Task<TResult> a_newTask, int a_delay = 0)
        {

            try
            {
                await TempTask;
            }
            catch
            {
                // ignored
            }

            OnPropertyChanged("Status", "IsCompleted", "IsNotCompleted");

            if (a_newTask.IsCanceled)
            {
                OnPropertyChanged("IsCanceled");
            }
            else if (a_newTask.IsFaulted)
            {
                OnPropertyChanged("IsFaulted", "Exception", "InnerException", "ErrorMessage");
            }
            else
            {
                OnPropertyChanged("IsSuccessfullyCompleted", "Result");
            }
        }

        public Task<TResult> TempTask { get; set; }
        public Task<TResult> Task { get; set; }
        public TResult Result => Task.Status == TaskStatus.RanToCompletion ? Task.Result : default(TResult);
        public TaskStatus Status => Task.Status;
        public bool IsCompleted => Task.IsCompleted;
        public bool IsNotCompleted => !Task.IsCompleted;
        public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;
        public bool IsCanceled => Task.IsCanceled;
        public bool IsFaulted => Task.IsFaulted;
        public AggregateException Exception => Task.Exception;
        public Exception InnerException => Exception?.InnerException;
        public string ErrorMessage => InnerException?.Message;
    }
}
