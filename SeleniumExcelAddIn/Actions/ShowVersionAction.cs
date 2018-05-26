// Copyright (c) 2014 Takashi Yoshizawa

namespace SeleniumExcelAddIn.Actions
{
    internal class ShowVersionAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.None;
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
            using (var form = new View.VersionForm())
            {
                form.ShowDialog();
            }
        }
    }
}
