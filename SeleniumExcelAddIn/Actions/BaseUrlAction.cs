// Copyright (c) 2014 Takashi Yoshizawa

namespace SeleniumExcelAddIn.Actions
{
    internal class BaseUrlAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.WorkbookPresent;
            }
        }

        public bool IsChecked
        {
            get
            {
                return false;
            }
        }

        public void Execute()
        {
            var workbookContext = App.Context.GetActiveWorkbookContext();

            using (View.BaseUrlForm form = new View.BaseUrlForm())
            {
                form.BaseUrl = workbookContext.BaseUrl;

                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbookContext.BaseUrl = form.BaseUrl;
                }
            }
        }
    }
}
