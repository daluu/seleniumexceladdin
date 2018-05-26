// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreCookiePresentCommand : ITestCommand
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
                return TestCommandResource.StoreCookiePresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreCookiePresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreCookiePresent_Value;
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

            var cookie = context.Driver.Manage().Cookies.GetCookieNamed(context.Target);

            var name = context.Target;
            var value = (cookie == null).ToString().ToLower();

            context.Set(name, value);
        }
    }
}
