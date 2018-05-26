using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace SeleniumExcelAddIn.v2010.Test
{
    public class TestContextMock : ITestContext
    {
        private IWebDriver driver;
        private string baseUrl;
        private readonly Dictionary<string, string> variables = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private static readonly Dictionary<string, string> KeyMaps = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "key.Add", Keys.Add },
            { "key.Alt", Keys.Alt },
            { "key.ArrowDown", Keys.ArrowDown },
            { "key.ArrowLeft", Keys.ArrowLeft },
            { "key.ArrowRight", Keys.ArrowRight },
            { "key.ArrowUp", Keys.ArrowUp },
            { "key.Backspace", Keys.Backspace },
            { "key.Cancel", Keys.Cancel },
            { "key.Clear", Keys.Clear },
            { "key.Command", Keys.Command },
            { "key.Control", Keys.Control },
            { "key.Decimal", Keys.Decimal },
            { "key.Delete", Keys.Delete },
            { "key.Divide", Keys.Divide },
            { "key.Down", Keys.Down },
            { "key.End", Keys.End },
            { "key.Enter", Keys.Enter },
            { "key.Equal", Keys.Equal },
            { "key.Escape", Keys.Escape },
            { "key.F1", Keys.F1 },
            { "key.F10", Keys.F10 },
            { "key.F11", Keys.F11 },
            { "key.F12", Keys.F12 },
            { "key.F2", Keys.F2 },
            { "key.F3", Keys.F3 },
            { "key.F4", Keys.F4 },
            { "key.F5", Keys.F5 },
            { "key.F6", Keys.F6 },
            { "key.F7", Keys.F7 },
            { "key.F8", Keys.F8 },
            { "key.F9", Keys.F9 },
            { "key.Help", Keys.Help },
            { "key.Home", Keys.Home },
            { "key.Insert", Keys.Insert },
            { "key.Left", Keys.Left },
            { "key.LeftAlt", Keys.LeftAlt },
            { "key.LeftControl", Keys.LeftControl },
            { "key.LeftShift", Keys.LeftShift },
            { "key.Meta", Keys.Meta },
            { "key.Multiply", Keys.Multiply },
            { "key.Null", Keys.Null },
            { "key.NumberPad0", Keys.NumberPad0 },
            { "key.NumberPad1", Keys.NumberPad1 },
            { "key.NumberPad2", Keys.NumberPad2 },
            { "key.NumberPad3", Keys.NumberPad3 },
            { "key.NumberPad4", Keys.NumberPad4 },
            { "key.NumberPad5", Keys.NumberPad5 },
            { "key.NumberPad6", Keys.NumberPad6 },
            { "key.NumberPad7", Keys.NumberPad7 },
            { "key.NumberPad8", Keys.NumberPad8 },
            { "key.NumberPad9", Keys.NumberPad9 },
            { "key.PageDown", Keys.PageDown },
            { "key.PageUp", Keys.PageUp },
            { "key.Pause", Keys.Pause },
            { "key.Return", Keys.Return },
            { "key.Right", Keys.Right },
            { "key.Semicolon", Keys.Semicolon },
            { "key.Separator", Keys.Separator },
            { "key.Shift", Keys.Shift },
            { "key.Space", Keys.Space },
            { "key.Subtract", Keys.Subtract },
            { "key.Tab", Keys.Tab },
            { "key.Up", Keys.Up },
        };

        public TestContextMock()
        {
            this.Timeout = TimeSpan.FromSeconds(5);
            this.variables = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            this.Clear();
        }

        public string Target
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string BaseUrl
        {
            get
            {
                return this.baseUrl;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.baseUrl = string.Empty;
                }
                else
                {
                    Uri url;

                    if (Uri.TryCreate(value, UriKind.Absolute, out url))
                    {
                        this.baseUrl = url.ToString();
                    }
                }
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref this.driver, () =>
                {
                    return new FirefoxDriver();
                });

            }
        }

        public void CreateDriver()
        {
            this.driver = new FirefoxDriver();
        }

        public string Get(string name)
        {
            if (string.IsNullOrWhiteSpace("name"))
            {
                throw new ArgumentNullException("name");
            }

            if (!this.variables.ContainsKey(name))
            {
                throw new InvalidOperationException(name);
            }

            return this.variables[name];
        }

        public void Set(string name, string value)
        {
            if (string.IsNullOrWhiteSpace("name"))
            {
                throw new ArgumentNullException("name");
            }

            if (this.variables.ContainsKey(name))
            {
                this.variables[name] = value ?? string.Empty;
            }
            else
            {
                this.variables.Add(name, value);
            }
        }

        public void Clear()
        {
            this.variables.Clear();

            foreach (var keyMap in KeyMaps)
            {
                this.variables.Add(keyMap.Key, keyMap.Value);
            }
        }

        public string GetAbsoluteUrl(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("urlString");
            }

            if (string.IsNullOrWhiteSpace(this.BaseUrl))
            {
                return value;
            }

            Uri u1 = new Uri(this.BaseUrl);
            Uri u2 = new Uri(u1, value);
            return u2.AbsoluteUri;
        }

        private Regex r = new Regex(@"\$\{(.*?)\}", RegexOptions.Compiled);

        private string Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            var ms = this.r.Matches(value);

            if (0 == ms.Count)
            {
                return value;
            }

            for (int i = 0; i < ms.Count; i++)
            {
                var m = ms[i];
                var g = m.Groups[1];
                var name = g.Value;
                string caputre = m.Captures[0].Value;

                value = value.Replace(caputre, this.Get(name));
            }

            return value;
        }

        public TimeSpan Timeout
        {
            get;
            set;
        }

        public WebDriverWait Wait
        {
            get
            {
                return new WebDriverWait(this.Driver, this.Timeout);
            }
        }

        public IWebElement FindElement(string locator)
        {
            if (string.IsNullOrWhiteSpace(locator))
            {
                throw new ArgumentNullException("locator");
            }

            var by = ElementLocator.Parse(locator);
            var element = this.Driver.FindElement(by);

            var remoteElement = element as RemoteWebElement;

            if (null != remoteElement)
            {
                var scrollIntoView = remoteElement.LocationOnScreenOnceScrolledIntoView;
            }

            return element;
        }

        public IEnumerable<IWebElement> FindElements(string locator)
        {
            if (string.IsNullOrWhiteSpace(locator))
            {
                throw new ArgumentNullException("locator");
            }

            var by = ElementLocator.Parse(locator);
            return this.Driver.FindElements(by);
        }

        public OpenQA.Selenium.Interactions.Actions Action
        {
            get
            {
                return new OpenQA.Selenium.Interactions.Actions(this.Driver);
            }
        }
    
        public Tuple<int, int> ParseCoordString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("value");
            }

            string[] s = value.Split(',');
            int x = Convert.ToInt16(s[0]);
            int y = Convert.ToInt16(s[1]);

            return new Tuple<int, int>(x, y);
        }

        public void HighlightElement(IWebElement element)
        {
            if (null == element)
            {
                return;
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)this.Driver;

            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
                element, "outline: 2px solid yellow;");

            System.Threading.Thread.Sleep(100);

            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
                element, "");
        }
    }
}
