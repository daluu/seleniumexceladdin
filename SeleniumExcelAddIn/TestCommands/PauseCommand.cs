// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace SeleniumExcelAddIn.TestCommands
{
    public class PauseCommand : ITestCommand
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
                return TestCommandResource.Pause;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.Pause_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.Pause_Value;
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

            int msec = int.Parse(context.Target);
            var t = TimeSpan.FromMilliseconds(msec);

            if (60 < t.TotalSeconds)
            {
                throw new IndexOutOfRangeException(Properties.Resources.PauseTimeOver);
            }

            Thread.Sleep(t);
        }
    }
}
