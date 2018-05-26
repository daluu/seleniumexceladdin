// Copyright (c) 2014 Takashi Yoshizawa

using System;
using OpenQA.Selenium.Remote;

namespace SeleniumExcelAddIn.TestCommands
{
    public class ClickCommand : ITestCommand
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
                return TestCommandResource.Click;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.Click_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.Click_Value;
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

            var element = context.FindElement(context.Target);
            element.Click();
        }
    }
}
