// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class x_AltKeyUpAndWaitCommand : ITestCommand
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
                return TestCommandResource.x_AltKeyUpAndWait;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.x_AltKeyUpAndWait_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.x_AltKeyUpAndWait_Value;
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

            x_AltKeyUpCommand.ExecuteInternal(context);
            TestCommandHelper.AndWait();
        }
    }
}
