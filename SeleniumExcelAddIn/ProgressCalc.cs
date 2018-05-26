// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;

namespace SeleniumExcelAddIn
{
    public class ProgressCalc : ObservableObject
    {
        private DateTime startTime;
        private long totalLong;
        private double totalDouble;
        private TimeSpan remainingTime;
        private string remainingTimeString;
        private int percentage;
        private string data;

        public TimeSpan RemainingTime
        {
            get
            {
                return this.remainingTime;
            }

            set
            {
                this.UpdateProperty<TimeSpan>(ref this.remainingTime, value, "RemainingTime");
            }
        }

        public string RemainingTimeString
        {
            get
            {
                return this.remainingTimeString;
            }

            set
            {
                this.UpdateProperty<string>(ref this.remainingTimeString, value, "RemainingTimeString");
            }
        }

        public int Percentage
        {
            get
            {
                return this.percentage;
            }

            set
            {
                this.UpdateProperty<int>(ref this.percentage, value, "Percentage");
            }
        }

        public string Data
        {
            get
            {
                return this.data;
            }

            set
            {
                this.UpdateProperty<string>(ref this.data, value, "Data");
            }
        }

        public void Start()
        {
            this.startTime = DateTime.Now;
            this.Percentage = 0;
            this.RemainingTime = new TimeSpan();
            this.remainingTimeString = string.Empty;
        }

        public void Update(long value, long total)
        {
            this.Update(value, total, string.Empty);
        }

        public void Update(long value, long total, string theData)
        {
            this.Data = theData;
            this.totalLong = total;
            this.totalDouble = (double)total;

            double v = Math.Max(1, Math.Min(value, this.totalLong));
            double perMillseconds = (DateTime.Now - this.startTime).TotalMilliseconds / v;
            double totalMillseconds = perMillseconds * this.totalDouble;
            DateTime endTime = this.startTime.AddMilliseconds(totalMillseconds);
            double reminSeconds = (endTime - DateTime.Now).TotalSeconds;

            this.Percentage = Math.Min(100, (int)Math.Floor(v / total * 100));
            this.RemainingTime = TimeSpan.FromSeconds(Math.Max(reminSeconds, 1));
            this.RemainingTimeString = FormatRemainingTime(this.RemainingTime);
        }

        private static string FormatRemainingTime(TimeSpan span)
        {
            if (span.TotalMinutes < 1)
            {
                return string.Format(
                    CultureInfo.CurrentCulture,
                   Properties.Resources.Progress_Secs,
                    span.Seconds);
            }

            if (span.TotalHours < 1)
            {
                return string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.Progress_Mins,
                    span.Minutes,
                    span.Seconds);
            }

            if (span.TotalDays < 1)
            {
                return string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.Progress_Hours,
                    span.Hours,
                    span.Minutes);
            }

            return string.Format(
                CultureInfo.CurrentCulture,
                Properties.Resources.Progress_Days,
                span.Days,
                span.Hours,
                span.Minutes);
        }
    }
}
