// Copyright (c) 2014 Takashi Yoshizawa

namespace SeleniumExcelAddIn
{
    internal interface IAction
    {
        ActionFlags Flags
        {
            get;
        }

        bool IsChecked
        {
            get;
        }

        void Execute();
    }
}
