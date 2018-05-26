// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertAlertPresentCommand : ITestCommand
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
                return TestCommandResource.AssertAlertPresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertAlertPresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertAlertPresent_Value;
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

            try
            {
                var alert = context.Driver.SwitchTo().Alert();
            }
            catch (OpenQA.Selenium.NoAlertPresentException ex)
            {
                TestCommandHelper.AssertFail(ex.Message);
            }
        }
    }
}
