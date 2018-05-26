// Copyright (c) 2014 Takashi Yoshizawa

namespace SeleniumExcelAddIn
{
    public class TestCaseSettings
    {
        public bool IsChecked;
        public TestResult Result;

        public TestCaseSettings()
        {
            this.IsChecked = true;
            this.Result = SeleniumExcelAddIn.TestResult.None;
        }
    }
}
