// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreElementPositionLeftCommand : ITestCommand
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
                return TestCommandResource.StoreElementPositionLeft;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreElementPositionLeft_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreElementPositionLeft_Value;
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

            string name = context.Value;
            string value = AssertElementPositionLeftCommand.GetActual(context).ToString();
            context.Set(name, value);
        }
    }
}
