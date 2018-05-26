using System;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	public delegate void WebBrowserExNavigateErrorEventHandler(object sender, AdvancedWebBrowserNavigateErrorEventArgs e);

	public class AdvancedWebBrowserNavigateErrorEventArgs : EventArgs
	{
		private String urlValue;
		private String frameValue;
		private Int32 statusCodeValue;
		private Boolean cancelValue;

		public AdvancedWebBrowserNavigateErrorEventArgs(String url, String frame, Int32 statusCode, Boolean cancel)
		{
			urlValue = url;
			frameValue = frame;
			statusCodeValue = statusCode;
			cancelValue = cancel;
		}

		public String Url
		{
			get { return urlValue; }
			set { urlValue = value; }
		}

		public String Frame
		{
			get { return frameValue; }
			set { frameValue = value; }
		}

		public Int32 StatusCode
		{
			get { return statusCodeValue; }
			set { statusCodeValue = value; }
		}

		public Boolean Cancel
		{
			get { return cancelValue; }
			set { cancelValue = value; }
		}
	}
}
