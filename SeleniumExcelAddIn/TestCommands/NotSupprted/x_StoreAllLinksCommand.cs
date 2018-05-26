// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class x_StoreAllLinksCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.None;
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
                return TestCommandResource.x_StoreAllLinks;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.x_StoreAllLinks_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.x_StoreAllLinks_Value;
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
    }
}
