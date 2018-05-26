// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public class WindowContext : ObservableObject, IWindowContext
    {
        private static readonly WindowContextNull NullContext = new WindowContextNull();
        private readonly View.ListPaneControl listControl;
        private readonly Microsoft.Office.Tools.CustomTaskPane listPane;
        private WorkbookContext workbookContext;
        private View.HelpPaneControl helpControl;
        private Microsoft.Office.Tools.CustomTaskPane helpPane;

        public WindowContext()
        {
            this.listControl = new View.ListPaneControl();
            this.listPane = App.TaskPanes.Add(this.listControl, Properties.Resources.ListPane_Title);
            this.listPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionLeft;
            this.listPane.Width = App.Context.Settings.ListPaneWidth;
            this.listPane.VisibleChanged += new EventHandler(this.listPane_VisibleChanged);
            this.listPane.Visible = App.Context.Settings.ListPaneVisible;
            this.listControl.Resize += new EventHandler(this.listControl_Resize);
        }

        public static IWindowContext Empty
        {
            get
            {
                return NullContext;
            }
        }

        public WorkbookContext WorkbookContext
        {
            get
            {
                return this.workbookContext;
            }

            set
            {
                if (this.UpdateProperty<WorkbookContext>(ref this.workbookContext, value, "WorkbookContext"))
                {
                    if (null == this.workbookContext)
                    {
                        this.listPane.Visible = false;
                        this.listControl.TestCases = null;
                    }
                    else
                    {
                        this.listControl.TestCases = this.workbookContext.TestCases;
                    }
                }
            }
        }

        public bool ListPaneVisible
        {
            get
            {
                return this.listPane.Visible;
            }

            set
            {
                this.listPane.Visible = value;
            }
        }

        public bool HelpPaneVisible
        {
            get
            {
                return (null == this.helpPane) ? false : this.helpPane.Visible;
            }

            set
            {
                if (value)
                {
                    if (null == this.helpPane)
                    {
                        this.helpControl = new View.HelpPaneControl();
                        this.helpPane = App.TaskPanes.Add(this.helpControl, Properties.Resources.HelpPaneTitle);
                        this.helpPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
                        this.helpPane.Width = App.Context.Settings.HelpPaneWidth;
                        this.helpPane.VisibleChanged += new EventHandler(this.helpPane_VisibleChanged);
                        this.helpControl.Resize += new EventHandler(this.helpControl_Resize);
                    }

                    if (!this.helpPane.Visible)
                    {
                        this.helpPane.Visible = true;
                        App.Excel.SheetSelectionChange += new Excel.AppEvents_SheetSelectionChangeEventHandler(this.Excel_SheetSelectionChange);
                    }
                }
                else
                {
                    if (null != this.helpPane)
                    {
                        if (this.helpPane.Visible)
                        {
                            this.helpPane.Visible = false;
                            App.Excel.SheetSelectionChange -= new Excel.AppEvents_SheetSelectionChangeEventHandler(this.Excel_SheetSelectionChange);
                        }
                    }
                }
            }
        }

        private void helpControl_Resize(object sender, EventArgs e)
        {
            App.Context.Settings.HelpPaneWidth = this.helpPane.Width;
        }

        private void listControl_Resize(object sender, EventArgs e)
        {
            App.Context.Settings.ListPaneWidth = this.listPane.Width;
        }

        private void helpPane_VisibleChanged(object sender, EventArgs e)
        {
            this.HelpPaneVisible = this.HelpPaneVisible;
            ActionManager.Update();
        }

        private void listPane_VisibleChanged(object sender, EventArgs e)
        {
            if (null == this.workbookContext)
            {
                return;
            }

            App.Context.Settings.ListPaneVisible = this.listPane.Visible;
            ActionManager.Update();
        }

        private void Excel_SheetSelectionChange(object sheet, Excel.Range range)
        {
            if (null == range.ListObject)
            {
                return;
            }

            if (!range.ListObject.Name.StartsWith(Properties.Resources.Prefix_Scenario))
            {
                return;
            }

            string s = range.Text;

            if (string.IsNullOrWhiteSpace(s))
            {
                return;
            }

            this.helpControl.CommandName = s;
        }
    }
}
