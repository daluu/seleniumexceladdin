// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreSelectedIdsCommand : ITestCommand
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
                return TestCommandResource.StoreSelectedIds;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreSelectedIds_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreSelectedIds_Value;
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

            IEnumerable<string> values = AssertSelectedIdsCommand.GetActual(context);

            var name = context.Value;
            var value = string.Join(",", values);

            context.Set(name, value);
        }
    }
}
