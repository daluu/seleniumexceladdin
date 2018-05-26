// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertConfirmationNotPresentCommand : ITestCommand
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
                return TestCommandResource.AssertConfirmationNotPresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertConfirmationNotPresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertConfirmationNotPresent_Value;
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

            TestCommandHelper.AssertNot(AssertConfirmationPresentCommand.ExecuteInternal, context);
        }
    }
}
