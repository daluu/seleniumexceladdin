using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	[System.Runtime.InteropServices.ComVisibleAttribute(true)]

	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
	public interface IServiceProvider
	{
		[PreserveSig]
		int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject);
	}

	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("79eac9ee-baf9-11ce-8c82-00aa004ba90b")]
	public interface IInternetSecurityManager
	{
		[PreserveSig]
		unsafe int SetSecuritySite(void* pSite);
		[PreserveSig]
		unsafe int GetSecuritySite(void** ppSite);
		[PreserveSig]
		unsafe int MapUrlToZone([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, int* pdwZone, [In] int dwFlags);
		[PreserveSig]
		unsafe int GetSecurityId([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, byte* pbSecurityId, int* pcbSecurityId, int dwReserved);
		[PreserveSig]
		unsafe int ProcessUrlAction([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, int dwAction, byte* pPolicy, int cbPolicy, byte* pContext, int cbContext, int dwFlags, int dwReserved);
		[PreserveSig]
		unsafe int QueryCustomPolicy([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, void* guidKey, byte** ppPolicy, int* pcbPolicy, byte* pContext, int cbContext, int dwReserved);
		[PreserveSig]
		int SetZoneMapping(int dwZone, [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern, int dwFlags);
		[PreserveSig]
		unsafe int GetZoneMappings(int dwZone, void** ppenumString, int dwFlags);
	}

	public static class Constants
	{
		public const int S_OK = 0;
		public const int E_NOINTERFACE = unchecked((int)0x80004002);
		public const int INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011);
		public enum UrlPolicy
		{
			URLPOLICY_ALLOW = 0,
			URLPOLICY_QUERY = 1,
			URLPOLICY_DISALLOW = 3,
		}
	}
	/// <summary>
	/// An extended version of the <see cref="WebBrowser"/> control.
	/// </summary>
	[ToolboxItem(true)]
	public class AdvancedWebBrowser : System.Windows.Forms.WebBrowser, IInternetSecurityManager
	{

		private const int OLECMDID_ZOOM = 63;
		private const int OLECMDEXECOPT_DONTPROMPTUSER = 2;

		private const int WAIT_FOR_SLEEP_TIME = 100;
		public const string ABOUT_BLANK = "about:blank";

		public event EventHandler GoBacked;
		public event EventHandler GoForwarded;
		public event EventHandler Stoped;
		public event WebBrowserNavigatedEventHandler NavigateComplete2;

		private static Guid IID_IInternetSecurityManager = Marshal.GenerateGuidForType(typeof(IInternetSecurityManager));

		public AdvancedWebBrowser()
		{
			this.Navigating += new WebBrowserNavigatingEventHandler(WebBrowserEx_Navigating);
			this.Navigated += new WebBrowserNavigatedEventHandler(WebBrowserEx_Navigated);
			this.NavigateError += new WebBrowserExNavigateErrorEventHandler(WebBrowserEx_NavigateError);
		}

		public static class Constants
		{
			public const int S_OK = 0;
			public const int E_NOINTERFACE = unchecked((int)0x80004002);
			public const int INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011);
			public enum UrlPolicy
			{
				URLPOLICY_ALLOW = 0,
				URLPOLICY_QUERY = 1,
				URLPOLICY_DISALLOW = 3,
			}
		}


		#region IServiceProvider Members

		public int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
		{
			if (guidService == IID_IInternetSecurityManager &&
				riid == IID_IInternetSecurityManager)
			{
				ppvObject = Marshal.GetComInterfaceForObject(this,
					typeof(IInternetSecurityManager));
				return Constants.S_OK;
			}
			ppvObject = IntPtr.Zero;
			return Constants.E_NOINTERFACE;
		}
		#endregion IServiceProvider Members

		#region IInternetSecurityManager Members
	
		public unsafe int SetSecuritySite(void* pSite)
		{
			return Constants.INET_E_DEFAULT_ACTION;
		}

		public unsafe int GetSecuritySite(void** ppSite)
		{
			return Constants.INET_E_DEFAULT_ACTION;
		}

		public unsafe int MapUrlToZone(string url, int* pdwZone, int dwFlags)
		{
			*pdwZone = 0;//local -> "Local", "Intranet", "Trusted", "Internet", "Restricted"
			return Constants.S_OK;
		}

		public unsafe int GetSecurityId(string url, byte* pbSecurityId, int* pcbSecurityId, int dwReserved)
		{
			return Constants.INET_E_DEFAULT_ACTION;
		}

		public unsafe int ProcessUrlAction(string url, int dwAction, byte* pPolicy, int cbPolicy,
			byte* pContext, int cbContext, int dwFlags, int dwReserved)
		{
			*((int*)pPolicy) = (int)Constants.UrlPolicy.URLPOLICY_ALLOW;
			return Constants.S_OK;
		}

		public unsafe int QueryCustomPolicy(string pwszUrl, void* guidKey, byte** ppPolicy, int* pcbPolicy, byte* pContext, int cbContext, int dwReserved)
		{
			return Constants.INET_E_DEFAULT_ACTION;
		}

		public int SetZoneMapping(int dwZone, string lpszPattern, int dwFlags)
		{
			return Constants.INET_E_DEFAULT_ACTION;
		}

		public unsafe int GetZoneMappings(int dwZone, void** ppenumString, int dwFlags)
		{
			return Constants.INET_E_DEFAULT_ACTION;
		}
		#endregion

		private Guid cmdGuid = new Guid("ED016940-BD5B-11CF-BA4E-00C04FD70816");

		public void ShowFindDialog()
		{
			IOleCommandTarget cmdt;
			Object o = new object();
			try
			{
				cmdt = (IOleCommandTarget)this.DomDocument;
				cmdt.Exec(ref cmdGuid, (uint)MiscCommandTarget.Find,
				(uint)SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref o, ref o);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.Print(e.Message);
			}
		}

		public void ViewSource()
		{
			IOleCommandTarget cmdt;
			Object o = new object();

			try
			{
				cmdt = (IOleCommandTarget)this.DomDocument;
				cmdt.Exec(ref cmdGuid, (uint)MiscCommandTarget.ViewSource,
				(uint)SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref o, ref o);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.Print(e.Message);
			}
		}

		public int DocumentMode
		{
			get
			{
				if (null == this.DomDocument6)
				{
					return 0;
				}

				float f = this.DomDocument6.documentMode;
				return (int)f;
			}
		}

		public string SelectionText
		{
			get
			{
				try
				{
					IHTMLSelectionObject selection = this.DomDocument2.selection;

					if (null == selection)
					{
						return String.Empty;
					}

					IHTMLTxtRange range = (IHTMLTxtRange)selection.createRange();

					if (null == range)
					{
						return String.Empty;
					}

					return range.text;
				}
				catch
				{
					return String.Empty;
				}
			}
		}

		public int TextSize
		{
			[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
			get
			{
				if (null == this.ActiveXInstance)
				{
					return 2;
				}

				object i = Type.Missing;
				object o = new object();

				try
				{
					if (this.IsDocumentNull)
					{
						return 2;
					}

					if (this.ReadyState != WebBrowserReadyState.Complete)
					{
						return 2;
					}

					((SHDocVw.IWebBrowser2)this.ActiveXInstance).ExecWB(
						SHDocVw.OLECMDID.OLECMDID_ZOOM,
						SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
						ref i,
						ref o);

					return (int)o;
				}
				catch
				{
					return 2;
				}
			}

			set
			{
				if (null == this.ActiveXInstance as SHDocVw.IWebBrowser2)
				{
					return;
				}

				if (this.ReadyState != WebBrowserReadyState.Complete)
				{
					return;
				}

				if (null == this.Document)
				{
					return;
				}


				if (value < 0 || 4 < value)
				{
					return;
				}

				object i = value;
				object o = Type.Missing;

				// ここは COM例外がいつもでる
				try
				{
					((SHDocVw.IWebBrowser2)this.ActiveXInstance).ExecWB(
						SHDocVw.OLECMDID.OLECMDID_ZOOM,
						SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
						ref i,
						ref o);
				}
				catch
				{
				}
			}
		}

		public int Zoom
		{
			//get
			//{
			//    object i = Type.Missing;
			//    object o = new object();

			//    // TODO: WebBrowserEx.Zoom の取得が動かない
			//    try
			//    {
			//        ((SHDocVw.IWebBrowser2)this.ActiveXInstance).ExecWB(
			//            (SHDocVw.OLECMDID)63,
			//            SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
			//            IntPtr.Zero,
			//            ref o);

			//        return (int)o;
			//    }
			//    catch(Exception exception)
			//    {
			//        System.Diagnostics.Debug.Print(exception.Message);
			//        return 100;
			//    }

			//}

			set
			{
				if (value < 10 || 1000 < value)
				{
					return;
				}

				try
				{
					object i = value;
					object o = Type.Missing;

					((SHDocVw.IWebBrowser2)this.ActiveXInstance).ExecWB(
						(SHDocVw.OLECMDID)63,
						SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
						ref i,
						ref o);
				}
				catch
				{
				}
			}
		}

		public string Encoding
		{
			get
			{
				return this.IsDocumentNotNull ? this.Document.Encoding : String.Empty;
			}
		}

		private bool IsCommandEnabled(string cmd)
		{
			return this.DomDocument2.queryCommandEnabled(cmd);
		}

		public string DocumentTextEx
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				this.GetFrameText(this.DomDocument2, sb);

				return sb.ToString();
			}
		}

		private void GetFrameText(IHTMLDocument2 domDocument, StringBuilder sb)
		{
			try
			{
				FramesCollection frames = domDocument.frames;

				sb.Append(domDocument.body.outerText);

				for (var i = 0; i < frames.length; i++)
				{
					object rindex = i;
					IHTMLWindow2 domWindow = (IHTMLWindow2)frames.item(ref rindex);
					this.GetFrameText(domWindow.document, sb);
				}
			}
			catch
			{
			}
		}

		public FramesCollection Frames
		{
			get
			{
				return this.DomDocument2.frames;
			}
		}

		public Control Control
		{
			get
			{
				return this;
			}
		}

		void WebBrowserEx_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
		}

		void WebBrowserEx_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
		}

		void WebBrowserEx_NavigateError(object sender, AdvancedWebBrowserNavigateErrorEventArgs e)
		{
		}

		public AdvancedWebBrowser WaitForDocumentCompleted()
		{
			System.Windows.Forms.Application.DoEvents();
			System.Threading.Thread.Sleep(WAIT_FOR_SLEEP_TIME);

			while (this.IsBusy == true || WebBrowserReadyState.Complete != this.ReadyState)
			{
				System.Threading.Thread.Sleep(WAIT_FOR_SLEEP_TIME);
				System.Windows.Forms.Application.DoEvents();
			}

			return this;
		}

		public Boolean IsDocumentNull
		{
			get
			{
				return null == this.Document;
			}
		}

		public Boolean IsDocumentNotNull
		{
			get
			{
				return !this.IsDocumentNull;
			}
		}

		public IHTMLDocument DomDocument
		{
			get
			{
				return this.Document.DomDocument as IHTMLDocument;
			}
		}

		public IHTMLDocument2 DomDocument2
		{
			get
			{
				return this.Document.DomDocument as IHTMLDocument2;
			}
		}

		public IHTMLDocument3 DomDocument3
		{
			get
			{
				return this.Document.DomDocument as IHTMLDocument3;
			}
		}

		public IHTMLDocument4 DomDocument4
		{
			get
			{
				return this.Document.DomDocument as IHTMLDocument4;
			}
		}

		public IHTMLDocument5 DomDocument5
		{
			get
			{
				return this.Document.DomDocument as IHTMLDocument5;
			}
		}

		public IHTMLDocument6 DomDocument6
		{
			get
			{
				if (null == this.Document)
				{
					return null;
				}

				return this.Document.DomDocument as IHTMLDocument6;
			}
		}

		internal UnsafeNativeMethods.IWebBrowser2 AxWebBrowser2;

		/// <summary>
		/// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
		/// Called by the control when the underlying ActiveX control is created.
		/// </summary>
		/// <param name="nativeActiveXObject"></param>
		[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
		protected override void AttachInterfaces(object nativeActiveXObject)
		{
			this.AxWebBrowser2 = (UnsafeNativeMethods.IWebBrowser2)nativeActiveXObject;
			base.AttachInterfaces(nativeActiveXObject);
		}

		/// <summary>
		/// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
		/// Called by the control when the underlying ActiveX control is discarded.
		/// </summary>
		[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
		protected override void DetachInterfaces()
		{
			this.AxWebBrowser2 = null;
			base.DetachInterfaces();
		}

		/// <summary>
		/// Returns the automation object for the web browser
		/// </summary>
		public object Application
		{
			get
			{
				return this.AxWebBrowser2.Application;
			}
		}

		System.Windows.Forms.AxHost.ConnectionPointCookie cookie;
		WebBrowserExEvents events;

		/// <summary>
		/// This method will be called to give you a chance to create your own event sink
		/// </summary>
		[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
		protected override void CreateSink()
		{
			// Make sure to call the base class or the normal events won't fire
			base.CreateSink();
			events = new WebBrowserExEvents(this);
			cookie = new AxHost.ConnectionPointCookie(this.ActiveXInstance, events, typeof(UnsafeNativeMethods.DWebBrowserEvents2));
		}

		/// <summary>
		/// Detaches the event sink
		/// </summary>
		[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
		protected override void DetachSink()
		{
			if (null != cookie)
			{
				cookie.Disconnect();
				cookie = null;
			}
		}

		/// <summary>
		/// Fires when downloading of a document begins
		/// </summary>
		public event EventHandler Downloading;

		/// <summary>
		/// Raises the <see cref="Downloading"/> event
		/// </summary>
		/// <param name="e">Empty <see cref="EventArgs"/></param>
		/// <remarks>
		/// You could start an animation or a notification that downloading is starting
		/// </remarks>
		protected void OnDownloading(EventArgs e)
		{
			if (null == this.Downloading)
			{
				return;
			}

			this.Downloading(this, e);
		}

		/// <summary>
		/// Fires when downloading is completed
		/// </summary>
		/// <remarks>
		/// Here you could start monitoring for script errors.
		/// </remarks>
		public event EventHandler DownloadComplete;
		/// <summary>
		/// Raises the <see cref="DownloadComplete"/> event
		/// </summary>
		/// <param name="e">Empty <see cref="EventArgs"/></param>
		protected virtual void OnDownloadComplete(EventArgs e)
		{
			if (null == this.DownloadComplete)
			{
				return;
			}

			this.DownloadComplete(this, e);
		}

		public event WebBrowserExNavigateErrorEventHandler NavigateError;

		// Raises the NavigateError event.
		protected virtual void OnNavigateError(AdvancedWebBrowserNavigateErrorEventArgs e)
		{
			if (null == this.NavigateError)
			{
				return;
			}

			this.NavigateError(this, e);
		}

		/// <summary>
		/// Fires before navigation occurs in the given object (on either a window or frameset element).
		/// </summary>
		public event WebBrowserExNavigatingEventHandler BeforeNavigate2;
		/// <summary>
		/// Raised when a new window is to be created. Extends DWebBrowserEvents2::NewWindow2 with additional information about the new window.
		/// </summary>
		public event WebBrowserExNavigatingEventHandler NewWindow3;

		/// <summary>
		/// Raises the <see cref="NewWindow3"/> event
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown when BrowserExtendedNavigatingEventArgs is null</exception>
		protected void OnNewWindow3(AdvancedWebBrowserNavigatingEventArgs e)
		{
			if (null == this.NewWindow3)
			{
				return;
			}

			this.NewWindow3(this, e);
		}

		/// <summary>
		/// Raises the <see cref="BeforeNavigate2"/> event
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown when BrowserExtendedNavigatingEventArgs is null</exception>
		protected void OnBeforeNavigate2(AdvancedWebBrowserNavigatingEventArgs e)
		{
			if (null == this.BeforeNavigate2)
			{
				return;
			}

			this.BeforeNavigate2(this, e);
		}

		protected void OnNavigateComplete2(WebBrowserNavigatedEventArgs e)
		{
			if (null == this.NavigateComplete2)
			{
				return;
			}

			this.NavigateComplete2(this, e);
		}
		#region The Implementation of DWebBrowserEvents2 for firing extra events

		//This class will capture events from the WebBrowser
		class WebBrowserExEvents : UnsafeNativeMethods.DWebBrowserEvents2
		{
			public WebBrowserExEvents()
			{
			}

			AdvancedWebBrowser _wb;

			public WebBrowserExEvents(AdvancedWebBrowser wb)
			{
				this._wb = wb;
			}

			#region DWebBrowserEvents2 Members

			public void NavigateError(
				object pDisp,
				ref object url,
				ref object frame,
				ref object statusCode,
				ref bool cancel)
			{
				// Raise the NavigateError event.
				this._wb.OnNavigateError(new AdvancedWebBrowserNavigateErrorEventArgs(
					(String)url,
					(String)frame,
					(Int32)statusCode,
					cancel)
					);
			}

			//Implement whichever events you wish
			public void BeforeNavigate2(
				object pDisp,
				ref object URL,
				ref object flags,
				ref object targetFrameName,
				ref object postData,
				ref object headers,
				ref bool cancel)
			{
				Uri urlStr = new Uri(URL.ToString());
				string targetFrameNameStr = (string)targetFrameName;

				AdvancedWebBrowserNavigatingEventArgs args = new AdvancedWebBrowserNavigatingEventArgs(
					pDisp,
					urlStr,
					flags,
					targetFrameNameStr,
					postData,
					headers,
					UrlContext.None
					);

				this._wb.OnBeforeNavigate2(args);

				cancel = args.Cancel;
				pDisp = args.AutomationObject;
				postData = args.PostData;
				headers = args.Headers;
			}

			//The NewWindow2 event, used on Windows XP SP1 and below
			public void NewWindow2(ref object pDisp, ref bool cancel)
			{
				AdvancedWebBrowserNavigatingEventArgs args = new AdvancedWebBrowserNavigatingEventArgs(
					pDisp,
					null,
					null,
					null,
					null,
					null,
					UrlContext.None
					);
				this._wb.OnNewWindow3(args);
				cancel = args.Cancel;
				pDisp = args.AutomationObject;
			}

			// NewWindow3 event, used on Windows XP SP2 and higher
			public void NewWindow3(
				ref object ppDisp,
				ref bool Cancel,
				uint dwFlags,
				string bstrUrlContext,
				string bstrUrl)
			{
				AdvancedWebBrowserNavigatingEventArgs args = new AdvancedWebBrowserNavigatingEventArgs(
					ppDisp,
					new Uri(bstrUrl),
					null,
					null,
					null,
					null,
					(UrlContext)dwFlags);

				this._wb.OnNewWindow3(args);
				Cancel = args.Cancel;
				ppDisp = args.AutomationObject;
			}

			// Fired when downloading begins
			public void DownloadBegin()
			{
				this._wb.OnDownloading(EventArgs.Empty);
			}


			// Fired when downloading is completed
			public void DownloadComplete()
			{
				this._wb.OnDownloadComplete(EventArgs.Empty);
			}

			#region Unused events

			// This event doesn't fire.
			[DispId(0x00000107)]
			public void WindowClosing(bool isChildWindow, ref bool cancel)
			{
			}

			public void OnQuit()
			{

			}

			public void StatusTextChange(string text)
			{
			}

			public void ProgressChange(int progress, int progressMax)
			{
			}

			public void TitleChange(string text)
			{
			}

			public void PropertyChange(string szProperty)
			{
			}

			public void NavigateComplete2(object pDisp, ref object URL)
			{
				WebBrowserNavigatedEventArgs e = new WebBrowserNavigatedEventArgs(new Uri(URL.ToString()));

				this._wb.OnNavigateComplete2(e);
			}

			public void DocumentComplete(object pDisp, ref object URL)
			{
			}

			public void OnVisible(bool visible)
			{
			}

			public void OnToolBar(bool toolBar)
			{
			}

			public void OnMenuBar(bool menuBar)
			{
			}

			public void OnStatusBar(bool statusBar)
			{
			}

			public void OnFullScreen(bool fullScreen)
			{
			}

			public void OnTheaterMode(bool theaterMode)
			{
			}

			public void WindowSetResizable(bool resizable)
			{
			}

			public void WindowSetLeft(int left)
			{
			}

			public void WindowSetTop(int top)
			{
			}

			public void WindowSetWidth(int width)
			{
			}

			public void WindowSetHeight(int height)
			{
			}

			public void SetSecureLockIcon(int secureLockIcon)
			{
			}

			public void FileDownload(ref bool cancel)
			{
			}

			public void PrintTemplateInstantiation(object pDisp)
			{
			}

			public void PrintTemplateTeardown(object pDisp)
			{
			}

			public void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
			{
			}

			public void PrivacyImpactedStateChange(bool bImpacted)
			{
			}

			public void CommandStateChange(int Command, bool Enable)
			{
			}

			public void ClientToHostWindow(ref int CX, ref int CY)
			{
			}
			#endregion

			#endregion
		}

		#endregion

		#region Raises the Quit event when the browser window is about to be destroyed

		/// <summary>
		/// Overridden
		/// </summary>
		/// <param name="m">The <see cref="Message"/> send to this procedure</param>
		[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == (int)WindowsMessages.WM_PARENTNOTIFY)
			{
				//int lp = m.LParam.ToInt32();
				int wp = m.WParam.ToInt32();

				int X = wp & 0xFFFF;
				//int Y = (wp >> 16) & 0xFFFF;
				if (X == (int)WindowsMessages.WM_DESTROY)
				{
					this.OnQuit();
				}
			}

			base.WndProc(ref m);
		}

		/// <summary>
		/// A list of all the available window messages
		/// </summary>
		enum WindowsMessages
		{
			WM_ACTIVATE = 0x6,
			WM_ACTIVATEAPP = 0x1C,
			WM_AFXFIRST = 0x360,
			WM_AFXLAST = 0x37F,
			WM_APP = 0x8000,
			WM_ASKCBFORMATNAME = 0x30C,
			WM_CANCELJOURNAL = 0x4B,
			WM_CANCELMODE = 0x1F,
			WM_CAPTURECHANGED = 0x215,
			WM_CHANGECBCHAIN = 0x30D,
			WM_CHAR = 0x102,
			WM_CHARTOITEM = 0x2F,
			WM_CHILDACTIVATE = 0x22,
			WM_CLEAR = 0x303,
			WM_CLOSE = 0x10,
			WM_COMMAND = 0x111,
			WM_COMPACTING = 0x41,
			WM_COMPAREITEM = 0x39,
			WM_CONTEXTMENU = 0x7B,
			WM_COPY = 0x301,
			WM_COPYDATA = 0x4A,
			WM_CREATE = 0x1,
			WM_CTLCOLORBTN = 0x135,
			WM_CTLCOLORDLG = 0x136,
			WM_CTLCOLOREDIT = 0x133,
			WM_CTLCOLORLISTBOX = 0x134,
			WM_CTLCOLORMSGBOX = 0x132,
			WM_CTLCOLORSCROLLBAR = 0x137,
			WM_CTLCOLORSTATIC = 0x138,
			WM_CUT = 0x300,
			WM_DEADCHAR = 0x103,
			WM_DELETEITEM = 0x2D,
			WM_DESTROY = 0x2,
			WM_DESTROYCLIPBOARD = 0x307,
			WM_DEVICECHANGE = 0x219,
			WM_DEVMODECHANGE = 0x1B,
			WM_DISPLAYCHANGE = 0x7E,
			WM_DRAWCLIPBOARD = 0x308,
			WM_DRAWITEM = 0x2B,
			WM_DROPFILES = 0x233,
			WM_ENABLE = 0xA,
			WM_ENDSESSION = 0x16,
			WM_ENTERIDLE = 0x121,
			WM_ENTERMENULOOP = 0x211,
			WM_ENTERSIZEMOVE = 0x231,
			WM_ERASEBKGND = 0x14,
			WM_EXITMENULOOP = 0x212,
			WM_EXITSIZEMOVE = 0x232,
			WM_FONTCHANGE = 0x1D,
			WM_GETDLGCODE = 0x87,
			WM_GETFONT = 0x31,
			WM_GETHOTKEY = 0x33,
			WM_GETICON = 0x7F,
			WM_GETMINMAXINFO = 0x24,
			WM_GETOBJECT = 0x3D,
			WM_GETTEXT = 0xD,
			WM_GETTEXTLENGTH = 0xE,
			WM_HANDHELDFIRST = 0x358,
			WM_HANDHELDLAST = 0x35F,
			WM_HELP = 0x53,
			WM_HOTKEY = 0x312,
			WM_HSCROLL = 0x114,
			WM_HSCROLLCLIPBOARD = 0x30E,
			WM_ICONERASEBKGND = 0x27,
			WM_IME_CHAR = 0x286,
			WM_IME_COMPOSITION = 0x10F,
			WM_IME_COMPOSITIONFULL = 0x284,
			WM_IME_CONTROL = 0x283,
			WM_IME_ENDCOMPOSITION = 0x10E,
			WM_IME_KEYDOWN = 0x290,
			WM_IME_KEYLAST = 0x10F,
			WM_IME_KEYUP = 0x291,
			WM_IME_NOTIFY = 0x282,
			WM_IME_REQUEST = 0x288,
			WM_IME_SELECT = 0x285,
			WM_IME_SETCONTEXT = 0x281,
			WM_IME_STARTCOMPOSITION = 0x10D,
			WM_INITDIALOG = 0x110,
			WM_INITMENU = 0x116,
			WM_INITMENUPOPUP = 0x117,
			WM_INPUTLANGCHANGE = 0x51,
			WM_INPUTLANGCHANGEREQUEST = 0x50,
			WM_KEYDOWN = 0x100,
			WM_KEYFIRST = 0x100,
			WM_KEYLAST = 0x108,
			WM_KEYUP = 0x101,
			WM_KILLFOCUS = 0x8,
			WM_LBUTTONDBLCLK = 0x203,
			WM_LBUTTONDOWN = 0x201,
			WM_LBUTTONUP = 0x202,
			WM_MBUTTONDBLCLK = 0x209,
			WM_MBUTTONDOWN = 0x207,
			WM_MBUTTONUP = 0x208,
			WM_MDIACTIVATE = 0x222,
			WM_MDICASCADE = 0x227,
			WM_MDICREATE = 0x220,
			WM_MDIDESTROY = 0x221,
			WM_MDIGETACTIVE = 0x229,
			WM_MDIICONARRANGE = 0x228,
			WM_MDIMAXIMIZE = 0x225,
			WM_MDINEXT = 0x224,
			WM_MDIREFRESHMENU = 0x234,
			WM_MDIRESTORE = 0x223,
			WM_MDISETMENU = 0x230,
			WM_MDITILE = 0x226,
			WM_MEASUREITEM = 0x2C,
			WM_MENUCHAR = 0x120,
			WM_MENUCOMMAND = 0x126,
			WM_MENUDRAG = 0x123,
			WM_MENUGETOBJECT = 0x124,
			WM_MENURBUTTONUP = 0x122,
			WM_MENUSELECT = 0x11F,
			WM_MOUSEACTIVATE = 0x21,
			WM_MOUSEFIRST = 0x200,
			WM_MOUSEHOVER = 0x2A1,
			WM_MOUSELAST = 0x20A,
			WM_MOUSELEAVE = 0x2A3,
			WM_MOUSEMOVE = 0x200,
			WM_MOUSEWHEEL = 0x20A,
			WM_MOVE = 0x3,
			WM_MOVING = 0x216,
			WM_NCACTIVATE = 0x86,
			WM_NCCALCSIZE = 0x83,
			WM_NCCREATE = 0x81,
			WM_NCDESTROY = 0x82,
			WM_NCHITTEST = 0x84,
			WM_NCLBUTTONDBLCLK = 0xA3,
			WM_NCLBUTTONDOWN = 0xA1,
			WM_NCLBUTTONUP = 0xA2,
			WM_NCMBUTTONDBLCLK = 0xA9,
			WM_NCMBUTTONDOWN = 0xA7,
			WM_NCMBUTTONUP = 0xA8,
			WM_NCMOUSEHOVER = 0x2A0,
			WM_NCMOUSELEAVE = 0x2A2,
			WM_NCMOUSEMOVE = 0xA0,
			WM_NCPAINT = 0x85,
			WM_NCRBUTTONDBLCLK = 0xA6,
			WM_NCRBUTTONDOWN = 0xA4,
			WM_NCRBUTTONUP = 0xA5,
			WM_NEXTDLGCTL = 0x28,
			WM_NEXTMENU = 0x213,
			WM_NOTIFY = 0x4E,
			WM_NOTIFYFORMAT = 0x55,
			WM_NULL = 0x0,
			WM_PAINT = 0xF,
			WM_PAINTCLIPBOARD = 0x309,
			WM_PAINTICON = 0x26,
			WM_PALETTECHANGED = 0x311,
			WM_PALETTEISCHANGING = 0x310,
			WM_PARENTNOTIFY = 0x210,
			WM_PASTE = 0x302,
			WM_PENWINFIRST = 0x380,
			WM_PENWINLAST = 0x38F,
			WM_POWER = 0x48,
			WM_PRINT = 0x317,
			WM_PRINTCLIENT = 0x318,
			WM_QUERYDRAGICON = 0x37,
			WM_QUERYENDSESSION = 0x11,
			WM_QUERYNEWPALETTE = 0x30F,
			WM_QUERYOPEN = 0x13,
			WM_QUEUESYNC = 0x23,
			WM_QUIT = 0x12,
			WM_RBUTTONDBLCLK = 0x206,
			WM_RBUTTONDOWN = 0x204,
			WM_RBUTTONUP = 0x205,
			WM_RENDERALLFORMATS = 0x306,
			WM_RENDERFORMAT = 0x305,
			WM_SETCURSOR = 0x20,
			WM_SETFOCUS = 0x7,
			WM_SETFONT = 0x30,
			WM_SETHOTKEY = 0x32,
			WM_SETICON = 0x80,
			WM_SETREDRAW = 0xB,
			WM_SETTEXT = 0xC,
			WM_SETTINGCHANGE = 0x1A,
			WM_SHOWWINDOW = 0x18,
			WM_SIZE = 0x5,
			WM_SIZECLIPBOARD = 0x30B,
			WM_SIZING = 0x214,
			WM_SPOOLERSTATUS = 0x2A,
			WM_STYLECHANGED = 0x7D,
			WM_STYLECHANGING = 0x7C,
			WM_SYNCPAINT = 0x88,
			WM_SYSCHAR = 0x106,
			WM_SYSCOLORCHANGE = 0x15,
			WM_SYSCOMMAND = 0x112,
			WM_SYSDEADCHAR = 0x107,
			WM_SYSKEYDOWN = 0x104,
			WM_SYSKEYUP = 0x105,
			WM_TCARD = 0x52,
			WM_TIMECHANGE = 0x1E,
			WM_TIMER = 0x113,
			WM_UNDO = 0x304,
			WM_UNINITMENUPOPUP = 0x125,
			WM_USER = 0x400,
			WM_USERCHANGED = 0x54,
			WM_VKEYTOITEM = 0x2E,
			WM_VSCROLL = 0x115,
			WM_VSCROLLCLIPBOARD = 0x30A,
			WM_WINDOWPOSCHANGED = 0x47,
			WM_WINDOWPOSCHANGING = 0x46,
			WM_WININICHANGE = 0x1A
		}


		/// <summary>
		/// Raises the <see cref="Quit"/> event
		/// </summary>
		protected void OnQuit()
		{
			if (null != this.Quit)
			{
				this.Quit(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Raised when the browser application quits
		/// </summary>
		/// <remarks>
		/// Do not confuse this with DWebBrowserEvents2.Quit... That's something else.
		/// </remarks>
		public event EventHandler Quit;


		#endregion
	}
}
