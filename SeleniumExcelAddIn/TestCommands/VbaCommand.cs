// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class VbaCommand : ITestCommand
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
                return TestCommandResource.VBA;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.VBA_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.VBA_Value;
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

            var macro = GetMacro(context.Target);
            var args = GetArgs(context.Target);
            var name = string.IsNullOrWhiteSpace(context.Value) ? "vba" : context.Value;

            switch (args.Count())
            {
                case 0:
                    context.Set(name, App.Excel.Run(macro));
                    break;

                case 1:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0)));
                    break;

                case 2:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1)));
                    break;

                case 3:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1),
                        args.ElementAt(2)));
                    break;

                case 4:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1),
                        args.ElementAt(2),
                        args.ElementAt(3)));
                    break;

                case 5:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1),
                        args.ElementAt(2),
                        args.ElementAt(3),
                        args.ElementAt(4)));
                    break;

                case 6:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1),
                        args.ElementAt(2),
                        args.ElementAt(3),
                        args.ElementAt(4),
                        args.ElementAt(5)));
                    break;

                case 7:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1),
                        args.ElementAt(2),
                        args.ElementAt(3),
                        args.ElementAt(4),
                        args.ElementAt(5),
                        args.ElementAt(6)));
                    break;

                case 8:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1),
                        args.ElementAt(2),
                        args.ElementAt(3),
                        args.ElementAt(4),
                        args.ElementAt(5),
                        args.ElementAt(6),
                        args.ElementAt(7)));
                    break;

                case 9:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1),
                        args.ElementAt(2),
                        args.ElementAt(3),
                        args.ElementAt(4),
                        args.ElementAt(5),
                        args.ElementAt(6),
                        args.ElementAt(7),
                        args.ElementAt(8)));
                    break;

                case 10:
                    context.Set(name, App.Excel.Run(
                        macro,
                        args.ElementAt(0),
                        args.ElementAt(1),
                        args.ElementAt(2),
                        args.ElementAt(3),
                        args.ElementAt(4),
                        args.ElementAt(5),
                        args.ElementAt(6),
                        args.ElementAt(7),
                        args.ElementAt(8),
                        args.ElementAt(9)));
                    break;
            }
        }

        public static string GetMacro(string s)
        {
            var i = s.IndexOf("=");

            if (-1 == i)
            {
                return s;
            }

            return s.Substring(0, i).Trim();
        }

        public static IEnumerable<string> GetArgs(string value)
        {
            var list = new List<string>();
            var i = value.IndexOf("=");

            if (-1 == i)
            {
                return list;
            }

            list.AddRange(value.Substring(i + 1).Split(',').Select(s => s.Trim()));

            return list;
        }
    }
}
