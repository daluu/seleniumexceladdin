// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn.TestCommands
{
    public class CaptureEntirePageScreenshotCommand : ITestCommand
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
                return TestCommandResource.CaptureEntirePageScreenshot;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.CaptureEntirePageScreenshot_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.CaptureEntirePageScreenshot_Value;
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

            ITakesScreenshot takesScreenshot = context.Driver as ITakesScreenshot;

            if (null == takesScreenshot)
            {
                throw new NotSupportedException();
            }

            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(context.Target, ImageFormat.Jpeg);
        }
    }
}
