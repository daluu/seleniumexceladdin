// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class MouseMoveAtCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.Both;
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
                return TestCommandResource.MouseMoveAt;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.MouseMoveAt_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.MouseMoveAt_Value;
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
            Tuple<int, int> t = context.ParseCoordString(context.Value);
            action.MoveToElement(element);
            action.MoveByOffset(t.Item1, t.Item2);
            action.Perform();
        }
    }
}
