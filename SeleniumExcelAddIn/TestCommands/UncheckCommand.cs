// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn.TestCommands
{
    public class UncheckCommand : ITestCommand
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
                return TestCommandResource.Uncheck;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.Uncheck_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.Uncheck_Value;
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

            if (element.Selected)
            {
                element.Click();
            }
        }
    }
}
