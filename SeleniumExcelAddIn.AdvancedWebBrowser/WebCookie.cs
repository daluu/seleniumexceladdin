using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	class WebCookie : IWebCookie
	{
		private IWebBrowserEx _wb;
		private Dictionary<string, string> _dic;

		public WebCookie(IWebBrowserEx wb)
		{
			if (null == wb)
			{
				throw new ArgumentNullException();
			}

			this._wb = wb;
			this._dic = new Dictionary<string, string>();
			this.ParseRawCookie();
		}

		public string Get(string key)
		{
			if (String.IsNullOrWhiteSpace(key))
			{
				throw new ArgumentNullException();
			}

			this.ParseRawCookie();

			if (!this._dic.ContainsKey(key))
			{
				throw new KeyNotFoundException();
			}

			return this._dic[key];
		}

		public void Set(string key, string value)
		{
			if (String.IsNullOrWhiteSpace(key))
			{
				throw new ArgumentNullException();
			}

			this._dic[key] = value;
		}

		public Boolean Has(string key)
		{
			if (String.IsNullOrWhiteSpace(key))
			{
				throw new ArgumentNullException();
			}
			
			this.ParseRawCookie();

			return this._dic.ContainsKey(key);
		}

		public void Clear()
		{
			this._dic.Clear();
		}

		public string[] Keys
		{
			get
			{
				this.ParseRawCookie();
				return this._dic.Keys.ToArray();
			}
		}

		private void ParseRawCookie()
		{
			this._dic.Clear();

			if (null == this._wb.Document)
			{
				return;
			}

			if (null == this._wb.Document.Cookie)
			{
				return;
			}

			string s = this._wb.Document.Cookie;
			string[] pairs = s.Split(';');

			foreach (string pair in pairs)
			{
				List<string> keyValue = pair.Split('=').ToList();
				string key = keyValue.FirstOrDefault().Trim();
				keyValue.RemoveAt(0);
				string value = keyValue.FirstOrDefault();

				this._dic.Add(key, value);
			}
		}

		public void WriteToDocument()
		{
			string s = this.ToString();

		}

		public void WriteToDocument(DateTime expires)
		{
			DateTime utc = System.TimeZoneInfo.ConvertTimeToUtc(expires, System.TimeZoneInfo.Local);

			string s = this.ToString() + "; expires=" + utc.ToString("r");
			System.Diagnostics.Debug.Print("CookieWrite = " + s);

			this._wb.DomDocument2.cookie = s;
		}

		public override string ToString()
		{
			this.ParseRawCookie();

			List<string> list = new List<string>();

			foreach (KeyValuePair<string, string> pair in this._dic)
			{
				list.Add(String.Format("{0}={1}", pair.Key, pair.Value));
			}

			string s = String.Join("; ", list);

			return s;
		}
	}
}
