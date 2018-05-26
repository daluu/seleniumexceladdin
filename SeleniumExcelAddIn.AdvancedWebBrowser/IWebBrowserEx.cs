using System;
using System.Drawing;
using System.Windows.Forms;
using mshtml;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
    public interface IWebBrowserEx
    {
        event EventHandler GoBacked;
        event EventHandler GoForwarded;
        event EventHandler Stoped;
        event WebBrowserExNavigatingEventHandler BeforeNavigate2;
        event WebBrowserExNavigatingEventHandler NewWindow3;
        event WebBrowserExNavigateErrorEventHandler NavigateError;
        event EventHandler Quit;

		Boolean CanGoBack { get; }
		Boolean CanGoForward { get; }
		Boolean CanUndo { get; }
		Boolean CanRedo { get; }
		Boolean CanCut { get; }
		Boolean CanCopy { get; }
		Boolean CanPaste { get; }
		Boolean CanDelete { get; }
		Boolean CanSelectAll { get; }

		IWebBrowserEx GoBlank();
		IWebBrowserEx GoBack();
		IWebBrowserEx GoForward();
		IWebBrowserEx GoHome();
		IWebBrowserEx Refresh();
		IWebBrowserEx Stop();
		IWebBrowserEx Undo();
		IWebBrowserEx Redo();
		IWebBrowserEx Cut();
		IWebBrowserEx Copy();
		IWebBrowserEx Paste();
		IWebBrowserEx Delete();
		IWebBrowserEx SelectAll();

		int DocumentMode { get; }
		int TextSize { get; set; }
		int Zoom { set; }
		string SelectionText { get; }
		Boolean IsWebBrowserContextMenuEnabled { get; set; }

		object Application { get; }
		IWebBrowserEx IWebBrowserEx { get; }
		FramesCollection Frames { get; }
		string DocumentTextEx { get; }

		Control Control { get; }
		Boolean IsDocumentNull { get; }
		Boolean IsDocumentNotNull { get; }
        HtmlDocument Document { get; }
        IHTMLDocument DomDocument { get; }
        IHTMLDocument2 DomDocument2 { get; }
        IHTMLDocument3 DomDocument3 { get; }
        IHTMLDocument4 DomDocument4 { get; }
		IHTMLDocument5 DomDocument5 { get; }
		IHTMLDocument6 DomDocument6 { get; }

		string Encoding { get; }
		IWebCookie Cookie { get; }
		object Tag { get; set; }

		IWebBrowserEx WaitForDocumentCompleted();

		IWebBrowserEx Navigate(string url);
        IWebBrowserEx Navigate(string url, string targetFrameName);
        IWebBrowserEx Navigate(Uri url);
        IWebBrowserEx Navigate(Uri url, string targetFrameName);
        IWebBrowserEx Navigate(string urlString, string targetFrameName, byte[] postData, string additionalHeaders);
        IWebBrowserEx Navigate(Uri urlString, string targetFrameName, byte[] postData, string additionalHeaders);

        // WebBrowser

        event EventHandler EncryptionLevelChanged;
        event EventHandler FileDownload;
        event WebBrowserNavigatedEventHandler Navigated;
        event WebBrowserNavigatingEventHandler Navigating;
        event EventHandler CanGoBackChanged;
        event EventHandler CanGoForwardChanged;
        event EventHandler StatusTextChanged;
        event EventHandler DocumentTitleChanged;
        event EventHandler Downloading;
        event EventHandler DownloadComplete;
        event WebBrowserDocumentCompletedEventHandler DocumentCompleted;
        event WebBrowserProgressChangedEventHandler ProgressChanged;

		Boolean IsOffline { get; }
        WebBrowserEncryptionLevel EncryptionLevel { get; }
        object ObjectForScripting { get; set; }
        WebBrowserReadyState ReadyState { get; }
        bool ScriptErrorsSuppressed { get; set; }
        bool ScrollBarsEnabled { get; set; }
		string StatusText { get; }
        Uri Url { get; set; }
        bool WebBrowserShortcutsEnabled { get; set; }
        string DocumentTitle { get; }
		Version Version { get; }
		Boolean IsBusy { get; }

        void Print();
        void ShowPageSetupDialog();
        void ShowPrintDialog();
        void ShowPrintPreviewDialog();
        void ShowPropertiesDialog();
        void ShowSaveAsDialog();
		void ShowFindDialog();
		void ViewSource();
    }
}
