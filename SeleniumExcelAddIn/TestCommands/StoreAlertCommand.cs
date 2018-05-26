// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreAlertCommand : ITestCommand
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
                return false;
            }
        }


        
        public string Description
        {
            get
            {
                return TestCommandResource.StoreAlert;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreAlert_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreAlert_Value;
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

            IAlert alert = context.Driver.SwitchTo().Alert();

            var name = context.Target;
            var value = alert.Text;

            context.Set(name, value);
        }
    }
}
