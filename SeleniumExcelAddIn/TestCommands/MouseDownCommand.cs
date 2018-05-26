// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class MouseDownCommand : ITestCommand
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
                return TestCommandResource.MouseDown;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.MouseDown_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.MouseDown_Value;
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
            var action = context.Action;
            action.MoveToElement(element);
            action.ClickAndHold(element);
            action.Perform();
        }
    }
}
