// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SeleniumExcelAddIn
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045")]
        protected bool UpdateProperty<T>(ref T field, T value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
//#if DEBUG
//            Log.Logger.DebugFormat("{0} = {1} = {2}", propertyName, field, text);
//#endif
            field = value;
            this.RaisePropertyChanged(propertyName);

            return true;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            var handler = this.PropertyChanged;

            if (null == handler)
            {
                return;
            }

            SynchronizationDispatcher.Invoke(() =>
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            });
        }
    }
}
