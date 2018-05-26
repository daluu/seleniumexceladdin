// Copyright (c) 2014 Takashi Yoshizawa

using System;
using OpenQA.Selenium;

namespace SeleniumExcelAddIn.TestCommands
{
    public class x_AltKeyUpCommand : ITestCommand
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
                return TestCommandResource.x_AltKeyUp;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.x_AltKeyUp_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.x_AltKeyUp_Value;
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
            var action = context.Action;
            action.KeyUp(Keys.Alt);
            action.Perform();
        }
    }
}
