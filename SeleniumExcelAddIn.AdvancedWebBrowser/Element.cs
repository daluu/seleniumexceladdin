using System;
using System.Drawing;
using mshtml;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	public class Element
	{
		public event WebElementEventHandler OnAbout;
		public event WebElementEventHandler OnClick;
		public event WebElementEventHandler OnDblClick;
		public event WebElementEventHandler OnChange;
		public event WebElementEventHandler OnSelect;
		public event WebElementEventHandler OnFocus;
		public event WebElementEventHandler OnBlur;
		public event WebElementEventHandler OnSubmit;
		public event WebElementEventHandler OnReset;
		public event WebElementEventHandler OnLoad;
		public event WebElementEventHandler OnUnload;
		public event WebElementEventHandler OnError;
		public event WebElementEventHandler OnKeyDown;
		public event WebElementEventHandler OnKeyUp;
		public event WebElementEventHandler OnKeyPress;
		public event WebElementEventHandler OnMouseDown;
		public event WebElementEventHandler OnMouseUp;
		public event WebElementEventHandler OnMouseOver;
		public event WebElementEventHandler OnMouseOut;
		public event WebElementEventHandler OnMouseMove;

		private ElementEventProxy _eventProxy;

		/// <summary>
		/// ファクトリメソッド
		/// </summary>
		/// <param name="domElement"></param>
		/// <returns></returns>
		public static Element Create(IHTMLElement domElement)
		{
			if (null == domElement)
			{
				throw new ArgumentNullException();
			}

			return new Element(domElement);
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="domElement"></param>
		private Element(IHTMLElement domElement)
		{
			if (null == domElement)
			{
				throw new ArgumentNullException();
			}

			this.DomElement = domElement;

			this._eventProxy = ElementEventProxy.Create(this, EventProxyHandler);
		}

		private void EventProxyHandler(object sender, ElementEventArgs e)
		{
			switch (e.EventName)
			{
				case ElementEventName.change:
					if (null != this.OnChange)
					{
						this.OnChange(this, e);
					}
					break;

				case ElementEventName.click:
					if (null != this.OnClick)
					{
						this.OnClick(this, e);
					}
					break;

				case ElementEventName.dblclick:
					if (null != this.OnDblClick)
					{
						this.OnDblClick(this, e);
					}
					break;

				case ElementEventName.focus:
					if (null != this.OnFocus)
					{
						this.OnFocus(this, e);
					}
					break;

				case ElementEventName.blur:
					if (null != this.OnBlur)
					{
						this.OnBlur(this, e);
					}
					break;

				case ElementEventName.keydown:
					if (null != this.OnKeyDown)
					{
						this.OnKeyDown(this, e);
					}
					break;

				case ElementEventName.keyup:
					if (null != this.OnKeyUp)
					{
						this.OnKeyUp(this, e);
					}
					break;

				case ElementEventName.keypress:
					if (null != this.OnKeyPress)
					{
						this.OnKeyPress(this, e);
					}
					break;

				case ElementEventName.mousedown:
					if (null != this.OnMouseDown)
					{
						this.OnMouseDown(this, e);
					}
					break;

				case ElementEventName.mouseup:
					if (null != this.OnMouseUp)
					{
						this.OnMouseUp(this, e);
					}
					break;

				case ElementEventName.mouseover:
					if (null != this.OnMouseOver)
					{
						this.OnMouseOver(this, e);
					}
					break;

				case ElementEventName.mouseout:
					if (null != this.OnMouseOut)
					{
						this.OnMouseOut(this, e);
					} break;

				case ElementEventName.mousemove:
					if (null != this.OnMouseMove)
					{
						this.OnMouseMove(this, e);
					}
					break;

				case ElementEventName.load:
					if (null != this.OnLoad)
					{
						this.OnLoad(this, e);
					}
					break;

				case ElementEventName.unload:
					if (null != this.OnUnload)
					{
						this.OnUnload(this, e);
					}
					break;

				case ElementEventName.reset:
					if (null != this.OnReset)
					{
						this.OnReset(this, e);
					}
					break;

				case ElementEventName.submit:
					if (null != this.OnSubmit)
					{
						this.OnSubmit(this, e);
					}
					break;

				case ElementEventName.select:
					if (null != this.OnSelect)
					{
						this.OnSelect(this, e);
					}
					break;

				case ElementEventName.error:
					if (null != this.OnError)
					{
						this.OnError(this, e);
					}
					break;

				case ElementEventName.about:
					if (null != this.OnAbout)
					{
						this.OnAbout(this, e);
					}
					break;
			}
		}

		private IHTMLEventObj CreateEventObj()
		{
			return ((IHTMLDocument4)this.DomElement.document).CreateEventObject();
		}

		public Boolean IsVisible
		{
			get
			{
				string display = this.DomElement2.currentStyle.display;
				//string visibility = this.DomElement2.currentStyle.visibility;

				return !display.Equals("none");
			}
		}

		public IHTMLDOMNode DomNode
		{
			get
			{
				return this.DomElement as IHTMLDOMNode;
			}
		}

		public IHTMLElement DomElement
		{
			get;
			private set;
		}

		public IHTMLElement2 DomElement2
		{
			get
			{
				return this.DomElement as IHTMLElement2;
			}
		}

		public IHTMLElement3 DomElement3
		{
			get
			{
				return this.DomElement as IHTMLElement3;
			}
		}

		public IHTMLElement4 DomElement4
		{
			get
			{
				return this.DomElement as IHTMLElement4;
			}
		}

		public string Text
		{
			get
			{
				string s = this.DomElement.innerText;

				if (String.IsNullOrWhiteSpace(s))
				{
					return String.Empty;
				}

				return s.Trim();
			}
		}

		public string TagName
		{
			get
			{
				return this.DomElement.tagName.ToLower();
			}

		}

		public string GetAttribute(string attributeName)
		{
			if (String.IsNullOrWhiteSpace(attributeName))
			{
				throw new ArgumentNullException();
			}

			IHTMLDOMAttribute domAttr = this.DomElement4.getAttributeNode(attributeName);

			if (null == domAttr)
			{
				return String.Empty;
			}

			return domAttr.nodeValue;
		}

		public Boolean HasAttribute(string attributeName)
		{
			if (String.IsNullOrWhiteSpace(attributeName))
			{
				throw new ArgumentNullException();
			}

			return !String.IsNullOrWhiteSpace(this.GetAttribute(attributeName));

			//IHTMLDOMAttribute domAttr = this.DomElement4.getAttributeNode(attributeName);

			//if (null == domAttr)
			//{
			//    return false;
			//}

			//return domAttr.specified;
		}

		public string Id
		{
			get
			{
				return this.DomElement.id;
			}
		}

		public Boolean IsEnabled
		{
			get
			{
				return !this.DomElement3.disabled;
			}

			set
			{
				this.DomElement3.disabled = !value;
			}
		}
	}
}
