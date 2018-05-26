// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Office.Tools.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace SeleniumExcelAddIn
{
    public partial class ThisAddIn
    {
        protected override object RequestComAddInAutomationService()
        {
            return (IAppContext)App.Context;
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            App.Excel = this.Application;
            App.TaskPanes = this.CustomTaskPanes;
            App.Context.Startup();
        }

        private void BeforeShutdown()
        {
            App.Context.Shutdown();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
