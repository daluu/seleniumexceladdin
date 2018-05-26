// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Runtime.InteropServices;

namespace SeleniumExcelAddIn
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("F712C1AF-788B-4846-A53B-F3C5EE4455DB")]
    public interface IWorkbookContext
    {
        string Id
        {
            get;
        }
    }
}
