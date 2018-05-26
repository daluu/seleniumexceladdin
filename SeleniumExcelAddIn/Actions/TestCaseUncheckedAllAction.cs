// Copyright (c) 2014 Takashi Yoshizawa

namespace SeleniumExcelAddIn.Actions
{
    internal class TestCaseUncheckedAllAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.None;
            }
        }

        public bool IsChecked
        {
            get
            {
                return false;
            }
        }

        public void Execute()
        {
            foreach (var testCase in App.Context.GetActiveWorkbookContext().TestCases)
            {
                testCase.IsChecked = false;
            }
        }
    }
}
