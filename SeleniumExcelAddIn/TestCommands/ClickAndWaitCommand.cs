// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace SeleniumExcelAddIn.TestCommands
{
    public class ClickAndWaitCommand : ITestCommand
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
                return true;
            }
        }

        
        public string Description
        {
            get
            {
                return TestCommandResource.ClickAndWait;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.ClickAndWait_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.ClickAndWait_Value;
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

            ClickCommand.ExecuteInternal(context);
            TestCommandHelper.AndWait();
        }
    }
}
