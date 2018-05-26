// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.Both;
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
                return TestCommandResource.Store;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.Store_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.Store_Value;
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

            var name = context.Value;
            var value = context.Target;
            context.Set(name, value);
        }
    }
}
