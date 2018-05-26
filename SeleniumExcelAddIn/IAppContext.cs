// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Runtime.InteropServices;

namespace SeleniumExcelAddIn
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("FF4A9587-1435-4ADB-A941-FDA67AB6A54C")]
    public interface IAppContext
    {
        Version Version
        {
            get;
        }

        IWorkbookContext ActiveWorkbookContext
        {
            get;
        }

        void Execute(string actionName);
    }
}
