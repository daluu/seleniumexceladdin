// Copyright (c) 2014 Takashi Yoshizawa

using System;
using OpenQA.Selenium;

namespace SeleniumExcelAddIn.TestCommands
{
    public class x_AltKeyDownCommand : ITestCommand
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
                return TestCommandResource.x_AltKeyDown;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.x_AltKeyDown_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.x_AltKeyDown_Value;
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

            var action = context.Action;
            action.KeyDown(Keys.Alt);
            action.Build();
            action.Perform();
        }
    }
}
