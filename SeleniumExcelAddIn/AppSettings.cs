// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.IO;
using Newtonsoft.Json;

namespace SeleniumExcelAddIn
{
    public class AppSettings
    {
        private const string SettingFileName = "settings.json";

        public AppSettings()
        {
            this.WebDriverType = Constants.InternetExplorer;
            
            this.ListPaneVisible = true;
            this.ListPaneWidth = 400;
            this.ListPaneTestCaseColumnWidth = 200;

            this.HelpPaneWidth = 300;

            this.FailedEvidenceRecord = true;
            this.PassedEvidenceRecord = false;
            this.Timeout = TimeSpan.FromSeconds(30);
            this.LastestUpdateNotify = DateTime.MinValue;
            this.ImportTestcaseInitialDirector = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public TimeSpan Timeout
        {
            get;
            set;
        }

        public bool ListPaneVisible
        {
            get;
            set;
        }

        public int ListPaneWidth
        {
            get;
            set;
        }

        public int ListPaneTestCaseColumnWidth
        {
            get;
            set;
        }

        public int HelpPaneWidth
        {
            get;
            set;
        }

        public string WebDriverType
        {
            get;
            set;
        }

        public bool FailedEvidenceRecord
        {
            get;
            set;
        }

        public bool PassedEvidenceRecord
        {
            get;
            set;
        }

        public DateTime LastestUpdateNotify
        {
            get;
            set;
        }

        public string ImportTestcaseInitialDirector
        {
            get;
            set;
        }

        public static AppSettings Load()
        {
            try
            {
                string path = Path.Combine(App.DataDir, SettingFileName);
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<AppSettings>(json);
            }
            catch (Exception ex)
            {
                Log.Logger.Warn(ex);
                return new AppSettings();
            }
        }

        public void Save()
        {
            string path = Path.Combine(App.DataDir, SettingFileName);
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
