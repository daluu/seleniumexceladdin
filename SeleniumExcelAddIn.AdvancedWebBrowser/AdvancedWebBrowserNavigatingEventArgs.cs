using System;
using System.ComponentModel;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	public delegate void WebBrowserExNavigatingEventHandler(object sender, AdvancedWebBrowserNavigatingEventArgs e);

	public class AdvancedWebBrowserNavigatingEventArgs : CancelEventArgs
	{
		private Uri _Url;
		/// <summary>
		/// The URL to navigate to
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public Uri Url
		{
			get { return _Url; }
		}

		private string _Frame;
		/// <summary>
		/// The name of the frame to navigate to
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public string Frame
		{
			get { return _Frame; }
		}

		private UrlContext navigationContext;
		/// <summary>
		/// The flags when opening a new window
		/// </summary>
		public UrlContext NavigationContext
		{
			get { return this.navigationContext; }
		}

		private object _pDisp;
		/// <summary>
		/// The pointer to ppDisp
		/// </summary>
		public object AutomationObject
		{
			get { return this._pDisp; }
			set { this._pDisp = value; }
		}

		public object Headers
		{
			get;
			set;
		}

		public object Flags
		{
			get;
			set;
		}

		public object PostData
		{
			get;
			set;
		}

		/// <summary>
		/// Creates a new instance of WebBrowserExtendedNavigatingEventArgs
		/// </summary>
		/// <param name="automation">Pointer to the automation object of the browser</param>
		/// <param name="url">The URL to go to</param>
		/// <param name="frame">The name of the frame</param>
		/// <param name="navigationContext">The new window flags</param>
		public AdvancedWebBrowserNavigatingEventArgs(
			object automation, 
			Uri url,
			object flags,
			string frame,
			object postData,
			object headers,
			UrlContext navigationContext
			)
			: base()
		{
			this._pDisp = automation;
			this._Url = url;
			this._Frame = frame;
			this.Flags = flags;
			this.PostData = postData;
			this.Headers = headers;
			this.navigationContext = navigationContext;
		}
	}
}
