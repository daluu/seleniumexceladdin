// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertSomethingSelectedCommand : ITestCommand
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
                return TestCommandResource.AssertSomethingSelected;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertSomethingSelected_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertSomethingSelected_Value;
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

            var element = context.FindElement(context.Target);
            var selectElement = new SelectElement(element);

            if (0 < selectElement.AllSelectedOptions.Count)
            {
                return;
            }

            TestCommandHelper.AssertFail();
        }
    }
}
