// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("908BD155-2B66-4A22-BADB-3ED0E7CEA62F")]
    public interface ITestCase : INotifyPropertyChanged
    {
        Excel.Workbook Workbook
        {
            get;
        }

        Excel.Worksheet Worksheet
        {
            get;
        }

        Excel.ListObject ListObject
        {
            get;
        }

        string Name
        {
            get;
        }

        string DisplayName
        {
            get;
        }

        string DataName
        {
            get;
            set;
        }

        string DataDisplayName
        {
            get;
        }

        string ResultLabel
        {
            get;
        }

        bool IsChecked
        {
            get;
            set;
        }

        void Update();
    }
}
