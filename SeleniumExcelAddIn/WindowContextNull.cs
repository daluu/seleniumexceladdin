// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public class WindowContextNull : ObservableObject, IWindowContext
    {
        public WindowContextNull()
        {
        }

        public WorkbookContext WorkbookContext
        {
            get
            {
                return null;
            }

            set
            {
                // NOP
            }
        }

        public bool ListPaneVisible
        {
            get
            {
                return false;
            }

            set
            {
                // NOP
            }
        }

        public bool HelpPaneVisible
        {
            get
            {
                return false;
            }

            set
            {
                // NOP
            }
        }
    }
}
