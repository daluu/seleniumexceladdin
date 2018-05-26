// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class DeleteCookieAndWaitCommand : ITestCommand
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
                return TestCommandResource.DeleteCookieAndWait;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.DeleteCookieAndWait_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.DeleteCookieAndWait_Value;
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

            DeleteCookieCommand.ExecuteInternal(context);
            TestCommandHelper.AndWait();
        }
    }
}
