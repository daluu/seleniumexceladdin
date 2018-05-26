// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreElementPresentCommand : ITestCommand
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
                return true;
            }
        }

        
        public string Description
        {
            get
            {
                return TestCommandResource.StoreElementPresent;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreElementPresent_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreElementPresent_Value;
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
            var value = true.ToString().ToLower();

            try
            {
                AssertElementPresentCommand.ExecuteInternal(context);
            }
            catch (TestAssertFailedException)
            {
                value = false.ToString().ToLower();
            }

            context.Set(name, value);
        }
    }
}
