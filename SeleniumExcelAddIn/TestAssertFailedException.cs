// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace SeleniumExcelAddIn
{
    [Serializable]
    public class TestAssertFailedException : Exception
    {
        public TestAssertFailedException()
            : base()
        {
        }

        public TestAssertFailedException(string message)
            : base(message)
        {
        }

        public TestAssertFailedException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public TestAssertFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public TestAssertFailedException(string format, Exception innerException, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, format, args), innerException)
        {
        }

        protected TestAssertFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
