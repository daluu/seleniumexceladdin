// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn.TestCommands
{
    public class SelectWindowCommand : ITestCommand
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
                return TestCommandResource.SelectWindow;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.SelectWindow_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.SelectWindow_Value;
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

            var window = context.Driver.SwitchTo().Window(context.Target);
        }
    }
}
