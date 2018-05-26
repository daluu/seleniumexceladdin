using System;
using System.Runtime.InteropServices;

namespace mshtml
{
	[TypeLibType(4160)]
	[Guid("30510417-98B5-11CF-BB82-00AA00BDCE0B")]
	public interface IHTMLDocument6
	{
		[DispId(1103)]
		IHTMLDocumentCompatibleInfoCollection compatible { get; }
		[DispId(1104)]
		dynamic documentMode { get; }
		[DispId(-2147412012)]
		dynamic onstorage { get; set; }
		[DispId(-2147412011)]
		dynamic onstoragecommit { get; set; }

		[DispId(1107)]
		IHTMLElement2 getElementById(string bstrId);
		[DispId(1109)]
		void updateSettings();
	}

	public interface IHTMLDocumentCompatibleInfoCollection
	{
		[DispId(1001)]
		int length { get; }

		[DispId(0)]
		IHTMLDocumentCompatibleInfo item(int index);
	}

	public interface IHTMLDocumentCompatibleInfo
	{
		[DispId(1001)]
		string userAgent { get; }
		[DispId(1002)]
		string version { get; }
	}

	public interface IHTMLElement5
	{
		[DispId(-2147416880)]
		string ariaActivedescendant { get; set; }
		[DispId(-2147416907)]
		string ariaBusy { get; set; }
		[DispId(-2147416906)]
		string ariaChecked { get; set; }
		[DispId(-2147416884)]
		string ariaControls { get; set; }
		[DispId(-2147416883)]
		string ariaDescribedby { get; set; }
		[DispId(-2147416905)]
		string ariaDisabled { get; set; }
		[DispId(-2147416904)]
		string ariaExpanded { get; set; }
		[DispId(-2147416882)]
		string ariaFlowto { get; set; }
		[DispId(-2147416903)]
		string ariaHaspopup { get; set; }
		[DispId(-2147416902)]
		string ariaHidden { get; set; }
		[DispId(-2147416901)]
		string ariaInvalid { get; set; }
		[DispId(-2147416881)]
		string ariaLabelledby { get; set; }
		[DispId(-2147416887)]
		short ariaLevel { get; set; }
		[DispId(-2147416877)]
		string ariaLive { get; set; }
		[DispId(-2147416900)]
		string ariaMultiselectable { get; set; }
		[DispId(-2147416879)]
		string ariaOwns { get; set; }
		[DispId(-2147416889)]
		short ariaPosinset { get; set; }
		[DispId(-2147416899)]
		string ariaPressed { get; set; }
		[DispId(-2147416898)]
		string ariaReadonly { get; set; }
		[DispId(-2147416876)]
		string ariaRelevant { get; set; }
		[DispId(-2147416897)]
		string ariaRequired { get; set; }
		[DispId(-2147416896)]
		string ariaSecret { get; set; }
		[DispId(-2147416895)]
		string ariaSelected { get; set; }
		[DispId(-2147416888)]
		short ariaSetsize { get; set; }
		[DispId(-2147416885)]
		string ariaValuemax { get; set; }
		[DispId(-2147416886)]
		string ariaValuemin { get; set; }
		[DispId(-2147416890)]
		string ariaValuenow { get; set; }
		[DispId(-2147416891)]
		IHTMLAttributeCollection3 attributes { get; }
		[DispId(-2147416908)]
		string role { get; set; }

		[DispId(-2147416894)]
		dynamic getAttribute(string strAttributeName);
		[DispId(-2147416912)]
		IHTMLDOMAttribute2 getAttributeNode(string bstrName);
		[DispId(-2147416909)]
		bool hasAttribute(string name);
		[DispId(-2147416878)]
		bool hasAttributes();
		[DispId(-2147416892)]
		bool removeAttribute(string strAttributeName);
		[DispId(-2147416910)]
		IHTMLDOMAttribute2 removeAttributeNode(IHTMLDOMAttribute2 pattr);
		[DispId(-2147416893)]
		void setAttribute(string strAttributeName, object AttributeValue);
		[DispId(-2147416911)]
		IHTMLDOMAttribute2 setAttributeNode(IHTMLDOMAttribute2 pattr);
	}

	public interface IHTMLCurrentStyle5
	{
		[DispId(-2147412885)]
		string borderSpacing { get; }
		[DispId(-2147412886)]
		string boxSizing { get; }
		[DispId(-2147412893)]
		string captionSide { get; }
		[DispId(-2147412862)]
		string emptyCells { get; }
		[DispId(-2147412861)]
		string msBlockProgression { get; }
		[DispId(-2147412884)]
		dynamic orphans { get; }
		[DispId(-2147412890)]
		string outline { get; }
		[DispId(-2147412887)]
		dynamic outlineColor { get; }
		[DispId(-2147412888)]
		string outlineStyle { get; }
		[DispId(-2147412889)]
		dynamic outlineWidth { get; }
		[DispId(-2147412882)]
		string pageBreakInside { get; }
		[DispId(-2147412860)]
		string quotes { get; }
		[DispId(-2147412883)]
		dynamic widows { get; }
	}

	public interface IHTMLWindow6
	{
		[DispId(1193)]
		IHTMLStorage localStorage { get; }
		[DispId(1194)]
		int maxConnectionsPerServer { get; }
		[DispId(-2147412003)]
		dynamic onhashchange { get; set; }
		[DispId(-2147412002)]
		dynamic onmessage { get; set; }
		[DispId(1192)]
		IHTMLStorage sessionStorage { get; }
		[DispId(1191)]
		dynamic XDomainRequest { get; set; }

		[DispId(1198)]
		void msWriteProfilerMark(string bstrProfilerMarkName);
		[DispId(1196)]
//		void postMessage(string msg, object targetOrigin = Type.Missing);
		void postMessage(string msg, object targetOrigin);
		[DispId(1197)]
		string toStaticHTML(string bstrHTML);
	}

	public interface IHTMLAttributeCollection3
	{
		[DispId(1153)]
		int length { get; }

		[DispId(1150)]
		IHTMLDOMAttribute getNamedItem(string bstrName);
		[DispId(1154)]
		IHTMLDOMAttribute item(int index);
		[DispId(1152)]
		IHTMLDOMAttribute removeNamedItem(string bstrName);
		[DispId(1151)]
		IHTMLDOMAttribute setNamedItem(IHTMLDOMAttribute pNodeIn);
	}

	public interface IHTMLStorage
	{
		[DispId(1001)]
		int length { get; }
		[DispId(1002)]
		int remainingSpace { get; }

		[DispId(1007)]
		void clear();
		[DispId(1003)]
		dynamic getItem(string bstrKey);
		[DispId(1006)]
		string key(int lIndex);
		[DispId(1005)]
		void removeItem(string bstrKey);
		[DispId(1004)]
		void setItem(string bstrKey, string bstrValue);
	}

	public interface IHTMLIFrameElement3
	{
		[DispId(-2147413992)]
		dynamic contentDocument { get; }
		[DispId(-2147413989)]
		string frameBorder { get; set; }
		[DispId(-2147413990)]
		string longDesc { get; set; }
		[DispId(-2147413991)]
		string src { get; set; }
	}
}