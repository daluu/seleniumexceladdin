// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class ChooseCancelOnNextConfirmationCommand : ITestCommand
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
                return TestCommandResource.ChooseCancelOnNextConfirmation;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.ChooseCancelOnNextConfirmation_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.ChooseCancelOnNextConfirmation_Value;
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
            alert.Dismiss();
        }
    }
}
