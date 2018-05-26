using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;


namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	#region

	/// <summary>
	/// Used by QueryUrl method
	/// </summary>
	public enum STATURL_QUERYFLAGS : uint
	{
		/// <summary>
		/// The specified URL is in the content cache.
		/// </summary>
		STATURL_QUERYFLAG_ISCACHED = 0x00010000,
		/// <summary>
		/// Space for the URL is not allocated when querying for STATURL.
		/// </summary>
		STATURL_QUERYFLAG_NOURL = 0x00020000,
		/// <summary>
		/// Space for the Web page's title is not allocated when querying for STATURL.
		/// </summary>
		STATURL_QUERYFLAG_NOTITLE = 0x00040000,
		/// <summary>
		/// //The item is a top-level item.
		/// </summary>
		STATURL_QUERYFLAG_TOPLEVEL = 0x00080000,

	}
	/// <summary>
	/// Flag on the dwFlags parameter of the STATURL structure, used by the SetFilter method.
	/// </summary>
	public enum STATURLFLAGS : uint
	{
		/// <summary>
		/// Flag on the dwFlags parameter of the STATURL structure indicating that the item is in the cache.
		/// </summary>
		STATURLFLAG_ISCACHED = 0x00000001,
		/// <summary>
		/// Flag on the dwFlags parameter of the STATURL structure indicating that the item is a top-level item.
		/// </summary>
		STATURLFLAG_ISTOPLEVEL = 0x00000002,
	}
	/// <summary>
	/// Used bu the AddHistoryEntry method.
	/// </summary>
	public enum ADDURL_FLAG : uint
	{
		/// <summary>
		/// Write to both the visited links and the dated containers. 
		/// </summary>
		ADDURL_ADDTOHISTORYANDCACHE = 0,
		/// <summary>
		/// Write to only the visited links container.
		/// </summary>
		ADDURL_ADDTOCACHE = 1
	}


	/// <summary>
	/// The structure that contains statistics about a URL. 
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct STATURL
	{
		/// <summary>
		/// Struct size
		/// </summary>
		public int cbSize;
		/// <summary>
		/// URL
		/// </summary>                                                                   
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwcsUrl;
		/// <summary>
		/// Page title
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwcsTitle;
		/// <summary>
		/// Last visited date (UTC)
		/// </summary>
		public System.Runtime.InteropServices.ComTypes.FILETIME ftLastVisited;
		/// <summary>
		/// Last updated date (UTC)
		/// </summary>
		public System.Runtime.InteropServices.ComTypes.FILETIME ftLastUpdated;
		/// <summary>
		/// The expiry date of the Web page's content (UTC)
		/// </summary>
		public System.Runtime.InteropServices.ComTypes.FILETIME ftExpires;
		/// <summary>
		/// Flags. STATURLFLAGS Enumaration.
		/// </summary>
		public STATURLFLAGS dwFlags;

		/// <summary>
		/// sets a column header in the DataGrid control. This property is not needed if you do not use it.
		/// </summary>
		public string URL
		{
			get { return pwcsUrl; }
		}
		/// <summary>
		/// sets a column header in the DataGrid control. This property is not needed if you do not use it.
		/// </summary>
		public string Title
		{
			get
			{
				if (pwcsUrl.StartsWith("file:"))
					return win32api.CannonializeURL(pwcsUrl, win32api.shlwapi_URL.URL_UNESCAPE).Substring(8).Replace('/', '\\');
				else
					return pwcsTitle;
			}
		}
		/// <summary>
		/// sets a column header in the DataGrid control. This property is not needed if you do not use it.
		/// </summary>
		public DateTime LastVisited
		{
			get
			{
				return win32api.FileTimeToDateTime(ftLastVisited).ToLocalTime();
			}
		}
		/// <summary>
		/// sets a column header in the DataGrid control. This property is not needed if you do not use it.
		/// </summary>
		public DateTime LastUpdated
		{
			get
			{
				return win32api.FileTimeToDateTime(ftLastUpdated).ToLocalTime();
			}
		}
		/// <summary>
		/// sets a column header in the DataGrid control. This property is not needed if you do not use it.
		/// </summary>
		public DateTime Expires
		{
			get
			{
				try
				{
					return win32api.FileTimeToDateTime(ftExpires).ToLocalTime();
				}
				catch (Exception)
				{
					return DateTime.Now;
				}
			}
		}

	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct UUID
	{
		public int Data1;
		public short Data2;
		public short Data3;
		public byte[] Data4;
	}

	//Enumerates the cached URLs
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("3C374A42-BAE4-11CF-BF7D-00AA006946EE")]
	public interface IEnumSTATURL
	{
		void Next(int celt, ref STATURL rgelt, out int pceltFetched);	//Returns the next \"celt\" URLS from the cache
		void Skip(int celt);	//Skips the next \"celt\" URLS from the cache. doed not work.
		void Reset();	//Resets the enumeration
		void Clone(out IEnumSTATURL ppenum);	//Clones this object
		void SetFilter([MarshalAs(UnmanagedType.LPWStr)] string poszFilter, STATURLFLAGS dwFlags);	//Sets the enumeration filter

	}


	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("3C374A41-BAE4-11CF-BF7D-00AA006946EE")]
	internal interface IUrlHistoryStg
	{
		void AddUrl(string pocsUrl, string pocsTitle, ADDURL_FLAG dwFlags);	//Adds a new history entry
		void DeleteUrl(string pocsUrl, int dwFlags);	//Deletes an entry by its URL. does not work!
		void QueryUrl([MarshalAs(UnmanagedType.LPWStr)] string pocsUrl, STATURL_QUERYFLAGS dwFlags, ref STATURL lpSTATURL);	//Returns a STATURL for a given URL
		void BindToObject([In] string pocsUrl, [In] UUID riid, IntPtr ppvOut); //Binds to an object. does not work!
		object EnumUrls { [return: MarshalAs(UnmanagedType.IUnknown)] get; }	//Returns an enumerator for URLs


	}

	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("AFA0DC11-C313-11D0-831A-00C04FD5AE38")]
	internal interface IUrlHistoryStg2 : IUrlHistoryStg
	{
		new void AddUrl(string pocsUrl, string pocsTitle, ADDURL_FLAG dwFlags);	//Adds a new history entry
		new void DeleteUrl(string pocsUrl, int dwFlags);	//Deletes an entry by its URL. does not work!
		new void QueryUrl([MarshalAs(UnmanagedType.LPWStr)] string pocsUrl, STATURL_QUERYFLAGS dwFlags, ref STATURL lpSTATURL);	//Returns a STATURL for a given URL
		new void BindToObject([In] string pocsUrl, [In] UUID riid, IntPtr ppvOut);	//Binds to an object. does not work!
		new object EnumUrls { [return: MarshalAs(UnmanagedType.IUnknown)] get; }	//Returns an enumerator for URLs

		void AddUrlAndNotify(string pocsUrl, string pocsTitle, int dwFlags, int fWriteHistory, object poctNotify, object punkISFolder);//does not work!
		void ClearHistory();	//Removes all history items


	}

	//UrlHistory class
	[ComImport]
	[Guid("3C374A40-BAE4-11CF-BF7D-00AA006946EE")]
	internal class UrlHistoryClass
	{
	}

	#endregion

	/// <summary>
	/// The class that wraps the C# equivalence of the IURLHistory Interface (in the file "urlhist.cs")
	/// </summary>
	internal class UrlHistoryProxy
	{

		UrlHistoryClass urlHistory;
		IUrlHistoryStg2 obj;

		/// <summary>
		/// Default constructor for UrlHistoryWrapperClass
		/// </summary>
		public UrlHistoryProxy()
		{
			urlHistory = new UrlHistoryClass();
			obj = (IUrlHistoryStg2)urlHistory;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public void Dispose()
		{
			Marshal.ReleaseComObject(obj);
			urlHistory = null;
		}

		/// <summary>
		/// Places the specified URL into the history. If the URL does not exist in the history, an entry is created in the history. If the URL does exist in the history, it is overwritten.
		/// </summary>
		/// <param name="pocsUrl">the string of the URL to place in the history</param>
		/// <param name="pocsTitle">the string of the title associated with that URL</param>
		/// <param name="dwFlags">the flag which indicate where a URL is placed in the history.
		/// <example><c>ADDURL_FLAG.ADDURL_ADDTOHISTORYANDCACHE</c></example>
		/// </param>
		public void AddEntry(string pocsUrl, string pocsTitle, ADDURL_FLAG dwFlags)
		{
			obj.AddUrl(pocsUrl, pocsTitle, dwFlags);
		}

		/// <summary>
		/// Deletes all instances of the specified URL from the history. does not work!
		/// </summary>
		/// <param name="pocsUrl">the string of the URL to delete.</param>
		/// <param name="dwFlags"><c>dwFlags = 0</c></param>
		public void DeleteEntry(string pocsUrl, int dwFlags)
		{
			try
			{
				obj.DeleteUrl(pocsUrl, dwFlags);
			}
			catch (Exception)
			{

			}
		}


		/// <summary>
		///Queries the history and reports whether the URL passed as the pocsUrl parameter has been visited by the current user. 
		/// </summary>
		/// <param name="pocsUrl">the string of the URL to querythe string of the URL to query.</param>
		/// <param name="dwFlags">STATURL_QUERYFLAGS Enumeration
		/// <example><c>STATURL_QUERYFLAGS.STATURL_QUERYFLAG_TOPLEVEL</c></example></param>
		/// <returns>Returns STATURL structure that received additional URL history information. If the returned  STATURL's pwcsUrl is not null, Queried URL has been visited by the current user.
		/// </returns>
		public STATURL QueryUrl(string pocsUrl, STATURL_QUERYFLAGS dwFlags)
		{
			STATURL lpSTATURL = new STATURL();

			try
			{
				//In this case, queried URL has been visited by the current user.
				obj.QueryUrl(pocsUrl, dwFlags, ref lpSTATURL);
				//lpSTATURL.pwcsUrl is NOT null;
				return lpSTATURL;
			}
			catch (FileNotFoundException)
			{
				//Queried URL has not been visited by the current user.
				//lpSTATURL.pwcsUrl is set to null;
				return lpSTATURL;
			}
		}

		/// <summary>
		/// Delete all the history except today's history, and Temporary Internet Files.
		/// </summary>
		public void ClearEntries()
		{
			obj.ClearHistory();
		}



		/// <summary>
		/// Create an enumerator that can iterate through the history cache. UrlHistoryWrapperClass does not implement IEnumerable interface 
		/// </summary>
		/// <returns>Returns STATURLEnumerator object that can iterate through the history cache.</returns>
		public STATURLEnumerator GetEnumerator()
		{
			return new STATURLEnumerator((IEnumSTATURL)obj.EnumUrls);
		}

		/// <summary>
		/// The inner class that can iterate through the history cache. STATURLEnumerator does not implement IEnumerator interface.
		/// The items in the history cache changes often, and enumerator needs to reflect the data as it existed at a specific point in time.
		/// </summary>
		public class STATURLEnumerator
		{
			IEnumSTATURL enumrator;
			int index;
			STATURL staturl;

			/// <summary>
			/// Constructor for <c>STATURLEnumerator</c> that accepts IEnumSTATURL object that represents the <c>IEnumSTATURL</c> COM Interface.
			/// </summary>
			/// <param name="enumrator">the <c>IEnumSTATURL</c> COM Interface</param>
			public STATURLEnumerator(IEnumSTATURL enumrator)
			{
				this.enumrator = enumrator;
			}
			//Advances the enumerator to the next item of the url history cache.
			/// <summary>
			/// Advances the enumerator to the next item of the url history cache.
			/// </summary>
			/// <returns>true if the enumerator was successfully advanced to the next element;
			///  false if the enumerator has passed the end of the url history cache.
			///  </returns>
			public bool MoveNext()
			{
				staturl = new STATURL();
				enumrator.Next(1, ref staturl, out index);
				if (index == 0)
					return false;
				else
					return true;
			}

			/// <summary>
			/// Gets the current item in the url history cache.
			/// </summary>
			public STATURL Current
			{
				get
				{
					return staturl;
				}
			}

			/// <summary>
			/// Skips a specified number of Call objects in the enumeration sequence. does not work!
			/// </summary>
			/// <param name="celt"></param>
			public void Skip(int celt)
			{
				enumrator.Skip(celt);
			}
			/// <summary>
			/// Resets the enumerator interface so that it begins enumerating at the beginning of the history. 
			/// </summary>
			public void Reset()
			{
				enumrator.Reset();
			}

			/// <summary>
			/// Creates a duplicate enumerator containing the same enumeration state as the current one. does not work!
			/// </summary>
			/// <returns>duplicate STATURLEnumerator object</returns>
			public STATURLEnumerator Clone()
			{
				IEnumSTATURL ppenum;
				enumrator.Clone(out ppenum);
				return new STATURLEnumerator(ppenum);

			}
			/// <summary>
			/// Define filter for enumeration. MoveNext() compares the specified URL with each URL in the history list to find matches. MoveNext() then copies the list of matches to a buffer. SetFilter method is used to specify the URL to compare.	 
			/// </summary>
			/// <param name="poszFilter">The string of the filter. 
			/// <example>SetFilter('http://', STATURL_QUERYFLAGS.STATURL_QUERYFLAG_TOPLEVEL)  retrieves only entries starting with 'http.//'. </example>
			/// </param>
			/// <param name="dwFlags">STATURL_QUERYFLAGS Enumeration<exapmle><c>STATURL_QUERYFLAGS.STATURL_QUERYFLAG_TOPLEVEL</c></exapmle></param>
			public void SetFilter(string poszFilter, STATURLFLAGS dwFlags)
			{
				enumrator.SetFilter(poszFilter, dwFlags);
			}
			/// <summary>
			///Enumerate the items in the history cache and store them in the IList object.
			/// </summary>
			/// <param name="list">IList object
			/// <example><c>ArrayList</c>object</example>
			/// </param>
			public void GetUrlHistory(IList list)
			{

				while (true)
				{
					staturl = new STATURL();
					enumrator.Next(1, ref staturl, out index);
					if (index == 0)
						break;
					list.Add(staturl);

				}
				enumrator.Reset();
			}
		}
	}
}
