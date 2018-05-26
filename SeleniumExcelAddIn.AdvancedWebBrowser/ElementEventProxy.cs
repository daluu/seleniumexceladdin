using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using mshtml;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
    internal class ElementEventProxy : IDisposable, IReflect
    {
        private Element element = null;
        private WebElementEventHandler eventHandler;
        private IReflect typeIReflectImplementation;

        interface IHtmlEvent
        {
            string type { get; }
        }

        private ElementEventProxy(Element element, WebElementEventHandler eventHandler)
        {
            if (null == element)
            {
                throw new ArgumentNullException();
            }

            if (null == eventHandler)
            {
                throw new ArgumentNullException();
            }

            this.element = element;
            this.eventHandler = eventHandler;
            Type type = typeof(ElementEventProxy);
            this.typeIReflectImplementation = type;

			this.Attach();
        }

        public static ElementEventProxy Create(Element element, WebElementEventHandler eventHandler)
        {
            return new ElementEventProxy(element, eventHandler);
        }

        private Boolean _isAttached = false;

        public void Attach()
        {
            if (_isAttached)
            {
                return;
            }

            _isAttached = true;

			string[] names = Enum.GetNames(typeof(ElementEventName));
			foreach (string name in names)
			{
				element.DomElement2.attachEvent("on" + name, this);
			}
		}

        /// <summary>
        /// detach only once (thread safe)
        /// </summary>
        public void Detach()
        {
            if (!_isAttached)
            {
                return;
            }

            _isAttached = false;

            lock (this)
            {
                if (null != this.element)
                {
					string[] names = Enum.GetNames(typeof(ElementEventName));
					foreach (string name in names)
					{
						element.DomElement2.detachEvent("on" + name, this);
					}
                }
            }
        }

         #region IReflect

        FieldInfo IReflect.GetField(string name, BindingFlags bindingAttr)
        {
            return this.typeIReflectImplementation.GetField(name, bindingAttr);
        }

        FieldInfo[] IReflect.GetFields(BindingFlags bindingAttr)
        {
            return this.typeIReflectImplementation.GetFields(bindingAttr);
        }

        MemberInfo[] IReflect.GetMember(string name, BindingFlags bindingAttr)
        {
            return this.typeIReflectImplementation.GetMember(name, bindingAttr);
        }

        MemberInfo[] IReflect.GetMembers(BindingFlags bindingAttr)
        {
            return this.typeIReflectImplementation.GetMembers(bindingAttr);
        }

        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr)
        {
            return this.typeIReflectImplementation.GetMethod(name, bindingAttr);
        }

        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return this.typeIReflectImplementation.GetMethod(name, bindingAttr, binder, types, modifiers);
        }

        MethodInfo[] IReflect.GetMethods(BindingFlags bindingAttr)
        {
            return this.typeIReflectImplementation.GetMethods(bindingAttr);
        }

        PropertyInfo[] IReflect.GetProperties(BindingFlags bindingAttr)
        {
            return this.typeIReflectImplementation.GetProperties(bindingAttr);
        }

        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr)
        {
            return this.typeIReflectImplementation.GetProperty(name, bindingAttr);
        }

        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return this.typeIReflectImplementation.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
        }

        object IReflect.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
        {
            if (name == "[DISPID=0]")
            {
                IHTMLEventObj eventObj = (IHTMLEventObj)args[0];

				if (null != this.eventHandler)
                {
					ElementEventName eventName = (ElementEventName)Enum.Parse(typeof(ElementEventName), eventObj.type);
                    this.eventHandler(this, new ElementEventArgs(this.element, eventName, eventObj));
                }
            }

            return null;
        }

        Type IReflect.UnderlyingSystemType
        {
            get
            {
                return this.typeIReflectImplementation.UnderlyingSystemType;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Detach();
        }

        #endregion
    }
}
