// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class RunScriptCommand : ITestCommand
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
                return TestCommandResource.x_RunScript;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.x_RunScript_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.x_RunScript_Value;
            }
        }

        public void Execute(ITestContext context)
        {
            if (null == context)
            {
                throw new ArgumentNullException("context");
            }

            throw new NotImplementedException();
        }

        public static void ExecuteInternal(ITestContext context)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)context.Driver;

            object result = js.ExecuteScript(context.Target);

            if (!string.IsNullOrWhiteSpace(context.Value))
            {
                if (null == result)
                {
                    context.Set(context.Value, string.Empty);
                }
                else
                {
                    context.Set(context.Value, result.ToString());
                }
            }
        }
    }
}
