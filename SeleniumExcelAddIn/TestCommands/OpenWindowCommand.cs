// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class OpenWindowCommand : ITestCommand
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
                return true;
            }
        }

        
        public string Description
        {
            get
            {
                return TestCommandResource.OpenWindow;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.OpenWindow_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.OpenWindow_Value;
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

            IJavaScriptExecutor jscript = context.Driver as IJavaScriptExecutor;
            string src = string.Format("window.open(\"{0}\", \"{1}\");",
                context.Target,
                context.Value);

            jscript.ExecuteScript(src);
        }
    }
}
