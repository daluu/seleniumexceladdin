using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	public interface IWebCookie
	{
		string Get(string key);
		void Set(string key, string value);
		Boolean Has(string key);
		void Clear();
		string[] Keys { get; }
		void WriteToDocument();
	}
}
