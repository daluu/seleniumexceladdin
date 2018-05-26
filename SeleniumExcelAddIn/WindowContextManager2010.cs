// Copyright (c) 2014 Takashi Yoshizawa

namespace SeleniumExcelAddIn
{
    public class WindowContextManager2010 : IWindowContextManager
    {
        private WindowContext windowContext;

        public WindowContextManager2010()
        {
            this.windowContext = new WindowContext();
        }

        public IWindowContext ActiveWindowContext
        {
            get
            {
                return this.windowContext;
            }
        }
    }
}
