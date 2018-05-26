// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertNotAlertCommand : ITestCommand
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
                return TestCommandResource.AssertNotAlert;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertNotAlert_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertNotAlert_Value;
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

            TestCommandHelper.AssertNot(AssertAlertCommand.ExecuteInternal, context);
        }
    }
}
