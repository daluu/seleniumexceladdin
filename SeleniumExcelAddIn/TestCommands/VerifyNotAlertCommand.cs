// Copyright (c) 2014 Takashi Yoshizawa

using System;
using OpenQA.Selenium;

namespace SeleniumExcelAddIn.TestCommands
{
    public class VerifyNotAlertCommand : ITestCommand
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
                return TestCommandResource.VerifyNotAlert;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.VerifyNotAlert_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.VerifyNotAlert_Value;
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

            TestCommandHelper.Verify(AssertNotAlertCommand.ExecuteInternal, context);
        }
    }
}
