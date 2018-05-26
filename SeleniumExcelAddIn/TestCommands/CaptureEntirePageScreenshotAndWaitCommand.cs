// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn.TestCommands
{
    public class CaptureEntirePageScreenshotAndWaitCommand : ITestCommand
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
                return TestCommandResource.CaptureEntirePageScreenshotAndWait;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.CaptureEntirePageScreenshotAndWait_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.CaptureEntirePageScreenshotAndWait_Value;
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

            CaptureEntirePageScreenshotCommand.ExecuteInternal(context);
            TestCommandHelper.AndWait();
        }
    }
}
