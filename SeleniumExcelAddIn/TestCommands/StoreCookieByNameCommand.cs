// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreCookieByNameCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.Both;
            }
        }

        public bool IsScreenCapture
        {
            get
            {
                return false;
            }
        }

        
        public string Description
        {
            get
            {
                return TestCommandResource.StoreCookieByName;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreCookieByName_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreCookieByName_Value;
            }
        }

        public void Execute(ITestContext context)

        {
            if (null == context)
            {
                throw new ArgumentNullException("context");
            }

            ExecuteInternal(context);
        }

        public static void ExecuteInternal(ITestContext context)
        {
            if (null == context)
            {
                throw new ArgumentNullException("context");
            }

            var cookie = context.Driver.Manage().Cookies.GetCookieNamed(context.Target);

            if (null == cookie)
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.NoSuchCookie,
                    context.Target));
            }

            var name = context.Value;
            var value = cookie.Value;

            context.Set(name, value);
        }
    }
}
