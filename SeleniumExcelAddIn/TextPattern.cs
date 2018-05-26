// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Text.RegularExpressions;

namespace SeleniumExcelAddIn
{
    public static class TextPattern
    {
        private static readonly DispatchDictionary<string, bool> Dic1 = new DispatchDictionary<string, bool>(DefaultEqual)
        {
            {
                "regexp:",
                RegExpMatch
            },
            {
                "regexpi:",
                RegExpMatchIgnoreCase
            },
        };

        private static readonly DispatchDictionary<string, bool> Dic2 = new DispatchDictionary<string, bool>(DefaultContains)
        {
            {
                "regexp:",
                RegExpMatch
            },
            {
                "regexpi:",
                RegExpMatchIgnoreCase
            },
        };

        public static bool IsMatch(string expected, string actual)
        {
            return Dic1.Dispatch(expected, actual);
        }

        public static bool IsContains(string expected, string actual)
        {
            return Dic2.Dispatch(expected, actual);
        }

        private static bool DefaultEqual(string expected, string actual)
        {
            return string.Equals(expected, actual, StringComparison.CurrentCulture);
        }

        private static bool DefaultContains(string exptected, string actual)
        {
            return 0 <= actual.IndexOf(exptected, StringComparison.OrdinalIgnoreCase);
        }

        private static bool RegExpMatch(string pattern, string actual)
        {
            return Regex.IsMatch(actual, pattern);
        }

        private static bool RegExpMatchIgnoreCase(string pattern, string actual)
        {
            return Regex.IsMatch(actual, pattern, RegexOptions.IgnoreCase);
        }
    }
}
