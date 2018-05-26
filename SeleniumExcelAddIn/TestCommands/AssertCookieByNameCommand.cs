// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertCookieByNameCommand : ITestCommand
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
                return TestCommandResource.AssertCookieByName;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertCookieByName_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertCookieByName_Value;
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
            var expected = context.Value;
            var actual = cookie.Value;

            TestCommandHelper.AssertAreEqual(expected, actual);
        }
    }
}
