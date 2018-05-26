// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;
using System.Threading;

namespace SeleniumExcelAddIn
{
    public static class TestCommandHelper
    {
        public static void AssertAreEqual(int expected, int actual)
        {
            AssertAreEqual(expected.ToString(), actual.ToString());
        }

        public static void AssertAreEqual(string expected, string actual)
        {
            if (!TextPattern.IsMatch(expected, actual))
            {
                throw new TestAssertFailedException(string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.AssertExpectedAndActual,
                    expected,
                    actual));
            }
        }

        public static void AssertAreNotEqual(string expected, string actual)
        {
            if (TextPattern.IsMatch(expected, actual))
            {
                throw new TestAssertFailedException(string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.AssertExpectedAndActual,
                    expected,
                    actual));
            }
        }

        public static void AssertAreContains(string expected, string actual)
        {
            if (!TextPattern.IsContains(expected, actual))
            {
                throw new TestAssertFailedException(string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.AssertExpected,
                    expected));
            }
        }

        public static void AssertAreNotContains(string expected, string actual)
        {
            if (TextPattern.IsContains(expected, actual))
            {
                throw new TestAssertFailedException(string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.AssertExpected,
                    expected));
            }
        }

        public static void AssertFail()
        {
            throw new TestAssertFailedException(Properties.Resources.AssertError);
        }

        public static void AssertFail(string message)
        {
            throw new TestAssertFailedException(message);
        }

        public static void AssertIsTrue(bool condition)
        {
            if (false == condition)
            {
                throw new TestAssertFailedException(Properties.Resources.AssertError);
            }
        }

        public static void AssertIsFalse(bool condition)
        {
            if (true == condition)
            {
                throw new TestAssertFailedException(Properties.Resources.AssertError);
            }
        }

        public static void AssertIsNull(object obj)
        {
            if (null != obj)
            {
                throw new TestAssertFailedException(Properties.Resources.AssertError);
            }
        }

        public static void AssertIsNotNull(object obj)
        {
            if (null == obj)
            {
                throw new TestAssertFailedException(Properties.Resources.AssertError);
            }
        }

        public static void AssertIsNotNull(object obj, string message)
        {
            if (null == obj)
            {
                throw new TestAssertFailedException(message);
            }
        }

        public static void AssertNot(Action<ITestContext> action, ITestContext context)
        {
            bool error = false;

            try
            {
                action(context);
                error = true;
            }
            catch (TestAssertFailedException)
            {
                // NOP               
            }

            if (error)
            {
                TestCommandHelper.AssertFail();
            }
        }

        public static void WaitFor(Action<ITestContext> action, ITestContext context)
        {
            context.Wait.Until((driver) =>
            {
                try
                {
                    action(context);
                    return true;
                }
                catch (TestAssertFailedException)
                {
                    return false;
                }
            });
        }

        public static void Verify(Action<ITestContext> action, ITestContext context)
        {
            try
            {
                action(context);
            }
            catch (TestAssertFailedException ex)
            {
                throw new TestVerifyFailedException(ex.Message);
            }
        }

        public static void AndWait()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}
