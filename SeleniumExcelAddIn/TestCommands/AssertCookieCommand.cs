// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertCookieCommand : ITestCommand
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
                return TestCommandResource.AssertCookie;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertCookie_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertCookie_Value;
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

            var cookies = context.Driver.Manage().Cookies.AllCookies;

            foreach (var cookie in cookies)
            {
                var expected = context.Target;
                var actual = cookie.ToString();

                TestCommandHelper.AssertAreEqual(expected, actual);
            }
        }
    }
}
