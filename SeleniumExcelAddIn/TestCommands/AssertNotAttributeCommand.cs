// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertNotAttributeCommand : ITestCommand
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
                return TestCommandResource.AssertNotAttribute;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertNotAttribute_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertNotAttribute_Value;
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

            TestCommandHelper.AssertNot(AssertAttributeCommand.ExecuteInternal, context);
        }
    }
}
