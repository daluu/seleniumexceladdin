// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreEditableCommand : ITestCommand
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
                return TestCommandResource.StoreEditable;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreEditable_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreEditable_Value;
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

            var name = context.Value;
            var value = true.ToString().ToLower();

            try
            {
                AssertEditableCommand.ExecuteInternal(context);
            }
            catch (TestAssertFailedException)
            {
                value = false.ToString().ToLower();
            }

            context.Set(name, value);
        }
    }
}
