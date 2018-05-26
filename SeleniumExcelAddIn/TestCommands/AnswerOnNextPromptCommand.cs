// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.ComponentModel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AnswerOnNextPromptCommand : ITestCommand
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
                return TestCommandResource.AnswerOnNextPrompt;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AnswerOnNextPrompt_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AnswerOnNextPrompt_Value;
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

            var alert = context.Driver.SwitchTo().Alert();
            alert.SendKeys(context.Target);
            alert.Accept();
        }
    }
}
