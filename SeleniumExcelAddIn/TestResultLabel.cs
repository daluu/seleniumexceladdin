// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn
{
    public static class TestResultLabel
    {
        private static readonly Dictionary<TestResult, string> dic = new Dictionary<TestResult, string>()
        {
            {
                TestResult.None, 
                Properties.Resources.TestResult_None
            },
            {
                TestResult.Skipped,
                Properties.Resources.TestResult_Skipped
            },
            {
                TestResult.Passed, 
                Properties.Resources.TestResult_Passed
            },
            {
                TestResult.Failed, 
                Properties.Resources.TestResult_Failed
            }
        };

        public static string GetText(TestResult result)
        {
            return dic[result];
        }
    }
}
