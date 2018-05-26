// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public class WindowContextManager2013 : IWindowContextManager
    {
        private Dictionary<string, WindowContext> dic = new Dictionary<string, WindowContext>();
        private DateTime purgeTime = DateTime.Now;

        public WindowContextManager2013()
        {
        }

        public IWindowContext ActiveWindowContext
        {
            get
            {
                if (0 == App.Excel.Workbooks.Count)
                {
                    return WindowContext.Empty;
                }

                WorkbookContext workbookContext = App.Context.GetActiveWorkbookContext();

                if (null == workbookContext)
                {
                    return WindowContext.Empty;
                }

                Excel.Window window = App.Excel.ActiveWindow;
                var key = workbookContext.Id;
                Log.Logger.DebugFormat("window key = {0}", key);

                if (this.dic.ContainsKey(key))
                {
                    return this.dic[key];
                }

                var windowContext = new WindowContext();

                this.dic.Add(key, windowContext);
                this.Purge();

                return windowContext;
            }
        }

        private void Purge()
        {
            var now = DateTime.Now;

            if ((now - this.purgeTime).TotalHours < 1)
            {
                return;
            }

            this.purgeTime = now;

            foreach (Excel.Workbook workbook in App.Excel.Workbooks)
            {
                var workbookContextId = WorkbookContext.GetContextId(workbook);

                if (!this.dic.ContainsKey(workbookContextId))
                {
                    this.dic.Remove(workbookContextId);
                }
            }
        }
    }
}
