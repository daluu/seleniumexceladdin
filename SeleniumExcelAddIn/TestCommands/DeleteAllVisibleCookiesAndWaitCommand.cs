// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class DeleteAllVisibleCookiesAndWaitCommand : ITestCommand
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
                return TestCommandResource.DeleteAllVisibleCookiesAndWait;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.DeleteAllVisibleCookiesAndWait_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.DeleteAllVisibleCookiesAndWait_Value;
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

            DeleteAllVisibleCookiesCommand.ExecuteInternal(context);
            TestCommandHelper.AndWait();
        }
    }
}
