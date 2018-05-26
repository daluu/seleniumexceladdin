// Copyright (c) 2014 Takashi Yoshizawa

using System;
using OpenQA.Selenium;

namespace SeleniumExcelAddIn.TestCommands
{
    public class VerifyAlertNotPresentCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.None;
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
                return TestCommandResource.VerifyAlertNotPresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.VerifyAlertNotPresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.VerifyAlertNotPresent_Value;
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

            TestCommandHelper.Verify(AssertAlertNotPresentCommand.ExecuteInternal, context);
        }
    }
}
