using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mshtml;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
    public class ElementEventArgs
    {
        public ElementEventArgs(Element element, ElementEventName eventName, IHTMLEventObj eventObj)
        {
			this.EventName = eventName;
            this.Element = element;
            this.EventObj = eventObj;
        }

		public ElementEventName EventName
		{
			get;
			private set;
		}

        public Element Element
        {
            get;
            private set;
        }

        public IHTMLEventObj EventObj
        {
            get;
            private set;
        }

    }
}
