// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumExcelAddIn
{
    public static class WebDriverFactory
    {
        private static readonly Dictionary<string, Func<IWebDriver>> DispatchTable = new Dictionary<string, Func<IWebDriver>>(StringComparer.OrdinalIgnoreCase)
        {
            {
                string.Empty,
                CreateInternetExplorerDriver
            },
            {
                Constants.InternetExplorer,
                CreateInternetExplorerDriver
            },
            {
                Constants.Firefox,
                CreateFirefoxDriver
            },
            {
                Constants.Chrome,
                CreateChromeDriver
            }
        };

        public static IWebDriver CreateWebDriver(string driverType)
        {
            if (!DispatchTable.ContainsKey(driverType))
            {
                Log.Logger.WarnFormat(Properties.Resources.WebDriverFactory_NotSupportedDriverType, driverType);
                return CreateInternetExplorerDriver();
            }

            return DispatchTable[driverType]();
        }

        private static IWebDriver CreateInternetExplorerDriver()
        {
            CopyInternetExplorerDriverBinary();

            var service = InternetExplorerDriverService.CreateDefaultService(App.DataDir);
            service.HideCommandPromptWindow = true;
            service.SuppressInitialDiagnosticInformation = true;
            service.LoggingLevel = InternetExplorerDriverLogLevel.Error;

            var options = new InternetExplorerOptions()
            {
                InitialBrowserUrl = "about:blank"
            };

            var driver = new InternetExplorerDriver(service, options);
            ResetZoom(driver);

            return driver;
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            var driver = new FirefoxDriver();
            driver.Url = "about:";

            return driver;
        }

        private static IWebDriver CreateChromeDriver()
        {
            CopyChromeDriverBinary();

            var service = ChromeDriverService.CreateDefaultService(App.DataDir);
            service.HideCommandPromptWindow = true;
            service.EnableVerboseLogging = false;
            service.SuppressInitialDiagnosticInformation = true;

            var options = new ChromeOptions();

            var driver = new ChromeDriver(service, options);
            driver.Url = "about:";

            return driver;
        }

        private static void ResetZoom(IWebDriver driver)
        {
            var element = driver.FindElement(By.TagName("body"));

            if (null != element)
            {
                if (element.Displayed)
                {
                    element.SendKeys(Keys.Control + "0");
                }
            }
        }

        private static void CopyInternetExplorerDriverBinary()
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            var path = Path.Combine(App.DataDir, "IEDriverServer.exe");

            if (File.Exists(path))
            {
                var file1 = new FileInfo(path);
                var file2 = new FileInfo(asm.Location);
#if DEBUG
                Log.Logger.DebugFormat("{0} = {1}", file1.LastWriteTime, asm.Location);
                Log.Logger.DebugFormat("{0} = {1}", file2.LastWriteTime, path);
#endif
                if (file2.LastWriteTime < file1.LastWriteTime)
                {
                    return;
                }
            }
#if DEBUG
            Log.Logger.DebugFormat("copy IEDriverServer.exe", path);
#endif
            byte[] buffer = Properties.Resources.IEDriverServer;

            try
            {
                File.WriteAllBytes(path, buffer);
            }
            catch (IOException ex)
            {
                Log.Logger.Warn(ex);
            }
        }

        private static void CopyChromeDriverBinary()
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            var path = Path.Combine(App.DataDir, "chromedriver.exe");

            if (File.Exists(path))
            {
                var file1 = new FileInfo(path);
                var file2 = new FileInfo(asm.Location);
#if DEBUG
                Log.Logger.DebugFormat("{0} = {1}", file1.LastWriteTime, asm.Location);
                Log.Logger.DebugFormat("{0} = {1}", file2.LastWriteTime, path);
#endif
                if (file2.LastWriteTime < file1.LastWriteTime)
                {
                    return;
                }
            }
#if DEBUG
            Log.Logger.DebugFormat("copy chromedriver.exe", path);
#endif
            byte[] buffer = Properties.Resources.chromedriver;

            try
            {
                File.WriteAllBytes(path, buffer);
            }
            catch (IOException ex)
            {
                Log.Logger.Warn(ex);
            }
        }
    }
}
