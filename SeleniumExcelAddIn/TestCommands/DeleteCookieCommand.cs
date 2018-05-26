// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class DeleteCookieCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.Target;
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
                return TestCommandResource.DeleteCookie;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.DeleteCookie_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.DeleteCookie_Value;
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

            context.Driver.Manage().Cookies.DeleteCookieNamed(context.Target);
        }
    }
}
