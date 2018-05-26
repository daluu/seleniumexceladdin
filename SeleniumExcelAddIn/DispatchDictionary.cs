// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;

namespace SeleniumExcelAddIn
{
    #region

    public class DispatchDictionary : Dictionary<string, Action<ITestContext, string>>
    {
        private Action<ITestContext, string> defaultFunc;

        public DispatchDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public DispatchDictionary(Action<ITestContext, string> defaultFunc)
        {
            this.defaultFunc = defaultFunc;
        }

        public void Dispatch(ITestContext context)
        {
            foreach (var pair in this)
            {
                if (context.Target.StartsWith(pair.Key, StringComparison.OrdinalIgnoreCase))
                {
                    var value = context.Target.Substring(pair.Key.Length);
                    pair.Value(context, value);
                }
            }

            if (null == this.defaultFunc)
            {
                throw new NotSupportedException(context.Target);
            }

            this.defaultFunc(context, context.Target);
        }
    }

    #endregion

    #region

    public class DispatchDictionary<TResult> : Dictionary<string, Func<string, TResult>>
    {
        private Func<string, TResult> defaultFunc;

        public DispatchDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public DispatchDictionary(Func<string, TResult> defaultFunc)
        {
            this.defaultFunc = defaultFunc;
        }

        public TResult Dispatch(string key)
        {
            foreach (var pair in this)
            {
                if (key.StartsWith(pair.Key, StringComparison.OrdinalIgnoreCase))
                {
                    var value = key.Substring(pair.Key.Length);
                    return pair.Value(value);
                }
            }

            if (null == this.defaultFunc)
            {
                throw new NotSupportedException(key);
            }

            return this.defaultFunc(key);
        }
    }

    #endregion

    #region

    public class DispatchDictionary<T1, TResult> : Dictionary<string, Func<string, string, TResult>>
    {
        private Func<string, string, TResult> defaultFunc;

        public DispatchDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public DispatchDictionary(Func<string, string, TResult> defaultFunc)
            : base(StringComparer.OrdinalIgnoreCase)
        {
            this.defaultFunc = defaultFunc;
        }

        public TResult Dispatch(string key, string arg1)
        {
            foreach (var pair in this)
            {
                if (key.StartsWith(pair.Key, StringComparison.OrdinalIgnoreCase))
                {
                    var value = key.Substring(pair.Key.Length);
                    return pair.Value(value, arg1);
                }
            }

            if (null == this.defaultFunc)
            {
                throw new NotSupportedException(key);
            }

            return this.defaultFunc(key, arg1);
        }
    }

    #endregion
}
