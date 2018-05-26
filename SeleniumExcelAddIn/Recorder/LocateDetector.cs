using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mshtml;

namespace SeleniumExcelAddIn.Recorder
{
    public static class LocateDetector
    {
        private static readonly List<Func<IHTMLElement, string>> dic = new List<Func<IHTMLElement, string>>()
        {
            ByLink,
            ByInputButton,
            ByButton,
            ByLabel,
            ByName,
            ByCss
        };

        public static string Detect(IHTMLElement element)
        {
            foreach (var func in dic)
            {
                string locator = func(element);

                if (!string.IsNullOrWhiteSpace(locator))
                {
                    return locator;
                }
            }

            return string.Empty;
        }

        public static string ByLink(IHTMLElement element)
        {
            if (!(element is IHTMLAnchorElement))
            {
                element = element.parentElement;
            }

            if (!(element is IHTMLAnchorElement))
            {
                return string.Empty;
            }

            string s = element.innerText;

            if (!string.IsNullOrWhiteSpace(s))
            {
                s = s.Trim();
            }

            if (string.IsNullOrWhiteSpace(s))
            {
                s = element.title;
            }

            if (string.IsNullOrWhiteSpace(s))
            {
                s = ((IHTMLAnchorElement)element).href;
            }

            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            return string.Format("link={0}", s);
        }

        public static string ByInputButton(IHTMLElement element)
        {
            IHTMLInputElement input = element as IHTMLInputElement;

            if (null == input)
            {
                return string.Empty;
            }

            string type = input.type.ToLower();

            if ("button" != type
                && "submit" != type
                && "reset" != type)
            {
                return string.Empty;
            }

            string s = input.value;

            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            return string.Format("button={0}", s);
        }

        public static string ByButton(IHTMLElement element)
        {
            IHTMLButtonElement button = element as IHTMLButtonElement;

            if (null == button)
            {
                return string.Empty;
            }

            string s = element.innerText;

            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            return string.Format("button={0}", s);
        }

        public static string ByLabel(IHTMLElement element)
        {
            IHTMLLabelElement label = element as IHTMLLabelElement;

            if (null == label)
            {
                return string.Empty;
            }

            return string.Format("label={0}", element.innerText.Trim());
        }

        public static string ByName(IHTMLElement element)
        {
            string name = IE.Element.GetAttribute(element, "name");

            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            if (IE.Element.IsRadioButtonElement(element))
            {
                string value = IE.Element.GetValue(element);
                return string.Format("input[type=radio][name=\"{0}\"][value=\"{1}\"]", name, value);
            }

            return string.Format("name={0}", name);
        }

        public static string ByCss(IHTMLElement element)
        {
            if (null == element)
            {
                return string.Empty;
            }

            string tag = element.tagName.ToLower();

            if (!string.IsNullOrWhiteSpace(element.id))
            {
                return string.Format("{0}#{1}", tag, element.id);
            }

            List<string> list = new List<string>();
            int eq = GetElementIndex(element);
            string cssClass = IE.Element.GetClassList(element).ElementAtOrDefault(0);

            if (0 != eq)
            {
                list.Add(string.Format("{0}:eq({1})", tag, eq));
            }
            else if (!string.IsNullOrWhiteSpace(cssClass))
            {
                list.Add(string.Format("{0}.{1}", tag, cssClass));
            }
            else
            {
                list.Add(string.Format("{0}", tag));
            }

            if (null != element.parentElement)
            {
                list.Add(ByCss(element.parentElement));
            }

            list.Reverse();

            return string.Join(" > ", list);
        }

        private static int GetElementIndex(IHTMLElement element)
        {
            IHTMLElement2 parentElement = element.parentElement as IHTMLElement2;

            if (null == parentElement)
            {
                return 0;
            }

            IHTMLElementCollection elementCollection = parentElement.getElementsByTagName(element.tagName);

            for (int i = 0; i < elementCollection.length; i++)
            {
                if (element == elementCollection.item(i))
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
