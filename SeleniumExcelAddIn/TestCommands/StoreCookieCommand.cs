// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreCookieCommand : ITestCommand
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
                return TestCommandResource.StoreCookie;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreCookie_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreCookie_Value;
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

            List<string> list = new List<string>();
            var cookies = context.Driver.Manage().Cookies;

            foreach (var cookie in cookies.AllCookies)
            {
                list.Add(cookie.ToString());
            }

            var name = context.Target;
            var value = string.Join(";", list);

            context.Set(name, value);
        }
    }
}
