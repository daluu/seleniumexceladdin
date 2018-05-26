// Copyright (c) 2014 Takashi Yoshizawa

using System;
using OpenQA.Selenium;

namespace SeleniumExcelAddIn.TestCommands
{
    public class CreateCookieCommand : ITestCommand
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
                return TestCommandResource.CreateCookie;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.CreateCookie_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.CreateCookie_Value;
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

            var cookie = new Cookie(context.Target, context.Value);
            context.Driver.Manage().Cookies.AddCookie(cookie);
        }
    }
}
