// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class SetTimeoutCommand : ITestCommand
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
                return TestCommandResource.SetTimeout;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.SetTimeout_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.SetTimeout_Value;
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

            var max = TimeSpan.FromHours(1);
            var val = TimeSpan.FromMilliseconds(Convert.ToDouble(context.Target));

            if (max < val)
            {
                throw new ArgumentOutOfRangeException(max.TotalMilliseconds.ToString());
            }

            context.Timeout = val;
        }
    }
}
