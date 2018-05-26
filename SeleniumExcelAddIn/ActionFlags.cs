// Copyright (c) 2014 Takashi Yoshizawa

using System;
using SeleniumExcelAddIn.ActionValidators;

namespace SeleniumExcelAddIn
{
    [Flags]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")]
    public enum ActionFlags
    {
        [ActionValidator(typeof(NoneActionValidator))]
        None = 0,

        [ActionValidator(typeof(WorkbookPresentActionValidator))]
        WorkbookPresent = 1 << 1,

        [ActionValidator(typeof(WorkbookEditableActionValidator))]
        WorkbookEditable = 1 << 2 | WorkbookPresent,

        [ActionValidator(typeof(ListRowActionValidator))]
        ListRow = 1 << 3,
    }
}
