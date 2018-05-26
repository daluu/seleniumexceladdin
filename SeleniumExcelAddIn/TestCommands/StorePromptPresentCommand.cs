// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StorePromptPresentCommand : ITestCommand
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
                return TestCommandResource.StorePromptPresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StorePromptPresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StorePromptPresent_Value;
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
                AssertAlertPresentCommand.ExecuteInternal(context);
            }
            catch (TestAssertFailedException)
            {
                value = false.ToString().ToLower();
            }

            context.Set(name, value);
        }
    }
}
