// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive;
using System.Reactive.Concurrency;

namespace SeleniumExcelAddIn
{
    public static class SynchronizationDispatcher
    {
        private static readonly SyncForm form = new SyncForm()
        {
            Opacity = 0,
            Width = 0,
            Height = 0,
            ShowInTaskbar = false,
            FormBorderStyle = FormBorderStyle.FixedToolWindow,
            WindowState = FormWindowState.Minimized
        };

        private class SyncForm : Form
        {
            internal SynchronizationContext GetContext()
            {
                return SynchronizationContext.Current;
            }

            internal TaskScheduler GetTaskScheduler()
            {
                return TaskScheduler.FromCurrentSynchronizationContext();
            }
        }

        static SynchronizationDispatcher()
        {
            form.Show();
            TaskScheduler = form.GetTaskScheduler();
            Context = form.GetContext();
            MainThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        public static TaskScheduler TaskScheduler
        {
            get;
            private set;
        }

        public static SynchronizationContext Context
        {
            get;
            private set;
        }

        private static int MainThreadId;

        public static void Invoke(Action action)
        {
            if (null == action)
            {
                throw new ArgumentNullException("action");
            }

            if (Thread.CurrentThread.ManagedThreadId == MainThreadId)
            {
                action();
            }
            else
            {
                Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, TaskScheduler);
            }
        }
    }
}
