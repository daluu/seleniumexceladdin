// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreConfirmationPresentCommand : ITestCommand
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
                return TestCommandResource.StoreConfirmationPresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreConfirmationPresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreConfirmationPresent_Value;
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

            var name = context.Target;
            var value = true.ToString().ToLower();

            try
            {
                IAlert alert = context.Driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                value = false.ToString().ToLower();
            }

            context.Set(name, value);
        }
    }
}
