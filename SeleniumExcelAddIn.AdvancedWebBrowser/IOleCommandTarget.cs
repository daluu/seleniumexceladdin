using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OLECMDTEXT
	{
		public uint cmdtextf;
		public uint cwActual;
		public uint cwBuf;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
		public char rgwz;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct OLECMD
	{
		public uint cmdID;
		public uint cmdf;
	}

	[ComImport,
	Guid("b722bccb-4e68-101b-a2bc-00aa00404770"),
	InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	interface IOleCommandTarget
	{
		void QueryStatus(ref Guid pguidCmdGroup, UInt32 cCmds,
			[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] OLECMD[] prgCmds, ref OLECMDTEXT CmdText);

		void Exec(ref Guid pguidCmdGroup, uint nCmdId, uint nCmdExecOpt, ref object pvaIn, ref object pvaOut);
	}

	enum MiscCommandTarget
	{
		Find = 1,
		ViewSource,
		Options
	}

}
