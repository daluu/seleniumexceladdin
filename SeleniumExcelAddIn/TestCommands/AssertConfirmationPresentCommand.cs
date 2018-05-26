// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertConfirmationPresentCommand : ITestCommand
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
                return TestCommandResource.AssertConfirmationPresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertConfirmationPresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertConfirmationPresent_Value;
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

            AssertAlertPresentCommand.ExecuteInternal(context);
        }
    }
}
