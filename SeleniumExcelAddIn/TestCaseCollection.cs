// Copyright (c) 2014 Takashi Yoshizawa

using System.Linq;
using System.ComponentModel;

namespace SeleniumExcelAddIn
{
    public class TestCaseCollection : BindingList<TestCase>
    {
        public int PassedCount()
        {
            return this.Where(i => i.Result == TestResult.Passed).Count();
        }

        public int FaildCount()
        {
            return this.Where(i => i.Result == TestResult.Failed).Count();
        }

        public int SkippedCount()
        {
            return this.Where(i => i.Result == TestResult.Skipped).Count();
        }
    }
}
