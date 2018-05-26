// Copyright (c) 2014 Takashi Yoshizawa

namespace SeleniumExcelAddIn
{
    public interface IWindowContext
    {
        WorkbookContext WorkbookContext
        {
            get;
            set;
        }

        bool ListPaneVisible
        {
            get;
            set;
        }

        bool HelpPaneVisible
        {
            get;
            set;
        }
    }
}
