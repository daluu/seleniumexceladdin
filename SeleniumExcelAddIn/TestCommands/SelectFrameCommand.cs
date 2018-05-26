// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumExcelAddIn.TestCommands
{
    public class SelectFrameCommand : ITestCommand
    {
        private static readonly DispatchDictionary dic = new DispatchDictionary(ByElement)
        {
            {
                "Index=",
                ByIndex
            },
            {
                "Element=",
                ByElement
            },
            {
                "Name=",
                ByName
            }
        };

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
                return TestCommandResource.SelectFrame;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.SelectFrame_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.SelectFrame_Value;
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

            dic.Dispatch(context);
        }

        private static void ByIndex(ITestContext context, string value)
        {
            int frameIndex = int.Parse(value);
            context.Driver.SwitchTo().Frame(frameIndex);
        }

        private static void ByElement(ITestContext context, string value)
        {
            var frameElement = context.FindElement(context.Target);
            context.Driver.SwitchTo().Frame(frameElement);
        }

        private static void ByName(ITestContext context, string value)
        {
            context.Driver.SwitchTo().Frame(value);
        }
    }
}
