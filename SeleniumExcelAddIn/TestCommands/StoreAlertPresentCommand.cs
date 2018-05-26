// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreAlertPresentCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.None;
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
                return TestCommandResource.StoreAlertPresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreAlertPresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreAlertPresent_Value;
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

            try
            {
                IAlert alert = context.Driver.SwitchTo().Alert();
                context.Set(context.Target, bool.TrueString);
            }
            catch (NoAlertPresentException)
            {
                context.Set(context.Target, bool.FalseString);
            }
        }
    }
}
