// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class OpenCommand : ITestCommand
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
                return TestCommandResource.Open;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.Open_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.Open_Value;
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

            context.Driver.Navigate().GoToUrl(context.GetAbsoluteUrl(context.Target));
        }
    }
}
