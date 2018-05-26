// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace SeleniumExcelAddIn
{
    [Serializable]
    public class TestVerifyFailedException : Exception
    {
        public TestVerifyFailedException()
            : base()
        {
        }

        public TestVerifyFailedException(string message)
            : base(message)
        {
        }

        public TestVerifyFailedException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public TestVerifyFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public TestVerifyFailedException(string format, Exception innerException, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, format, args), innerException)
        {
        }

        protected TestVerifyFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
