// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn.ActionValidators
{
    internal class WorkbookPresentActionValidator : IActionValidator
    {
        public string Validate()
        {
            if (0 == App.Excel.Workbooks.Count)
            {
                return Properties.Resources.ActionValidator_WorkbookNotPresent;
            }

            return string.Empty;
        }
    }
}
