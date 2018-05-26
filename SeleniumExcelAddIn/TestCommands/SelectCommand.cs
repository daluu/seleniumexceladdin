// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn.TestCommands
{
    public class SelectCommand : ITestCommand
    {
        private static readonly Dictionary<string, Action<SelectElement, string>> dic = new Dictionary<string, Action<SelectElement, string>>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "Id=", 
                ById
            },
            {
                "Index=", 
                ByIndex
            }, 
            {
                "Label=", 
                ByLabel
            },
            {
                "Value=", 
                ByValue
            }
        };

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
                return TestCommandResource.Select;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.Select_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.Select_Value;
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

            foreach (var pair in dic)
            {
                if (context.Value.StartsWith(pair.Key, StringComparison.OrdinalIgnoreCase))
                {
                    string v = context.Value.Substring(pair.Key.Length);
                    pair.Value(selectElement, v);
                    return;
                }
            }

            ByLabel(selectElement, context.Value);
        }

        private static void ById(SelectElement selectElement, string value)
        {
            for (int i = 0; i < selectElement.Options.Count; i++)
            {
                var optionElement = selectElement.Options[i];
                if (optionElement.GetAttribute("id") == value)
                {
                    selectElement.SelectByIndex(i);
                    return;
                }
            }

            throw new InvalidOperationException(string.Format(
                CultureInfo.CurrentCulture,
                Properties.Resources.NoSuchSelectById,
                value));
        }

        private static void ByIndex(SelectElement selectElement, string value)
        {
            int i = int.Parse(value);
            selectElement.SelectByIndex(i);
        }

        private static void ByLabel(SelectElement selectElement, string value)
        {
            selectElement.SelectByText(value);
        }

        private static void ByValue(SelectElement selectElement, string value)
        {
            selectElement.SelectByValue(value);
        }
    }
}
