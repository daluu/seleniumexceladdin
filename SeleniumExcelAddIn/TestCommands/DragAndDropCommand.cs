// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class DragAndDropCommand : ITestCommand
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
                return TestCommandResource.DragAndDrop;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.DragAndDrop_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.DragAndDrop_Value;
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

            var action = context.Action;
            var src = context.FindElement(context.Target);
            string[] offset = context.Value.Split(',');
            int offsetX = Convert.ToInt16(offset[0]);
            int offsetY = Convert.ToInt16(offset[1]);

            action.DragAndDropToOffset(src, offsetX, offsetY);
            action.Perform();
        }
    }
}
