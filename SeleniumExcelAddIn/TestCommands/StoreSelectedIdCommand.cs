// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreSelectedIdCommand : ITestCommand
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
                return TestCommandResource.StoreSelectedId;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreSelectedId_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreSelectedId_Value;
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

            IEnumerable<string> values = AssertSelectedIdCommand.GetActual(context);

            var name = context.Value;
            var value = string.Join(",", values);

            context.Set(name, value);
        }
    }
}
