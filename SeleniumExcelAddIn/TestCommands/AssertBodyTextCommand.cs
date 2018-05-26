// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertBodyTextCommand : ITestCommand
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
                return TestCommandResource.AssertBodyText;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertBodyText_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertBodyText_Value;
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

            var expected = context.Target;
            var actual = context.FindElement("body").Text;

            TestCommandHelper.AssertAreContains(expected, actual);
        }
    }
}
