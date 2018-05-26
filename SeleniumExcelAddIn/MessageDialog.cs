// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SeleniumExcelAddIn
{
    public static class MessageDialog
    {
        public static string Title
        {
            get;
            set;
        }

        public static bool IsSilent
        {
            get;
            set;
        }

        public static void Info(object value, params object[] args)
        {
            Show(MessageBoxIcon.Information, value, args);
        }

        public static void Warn(object value, params object[] args)
        {
            Show(MessageBoxIcon.Warning, value, args);
        }

        public static void Error(object value, params object[] args)
        {
            Show(MessageBoxIcon.Error, value, args);
        }

        public static bool Confirm(object value, params object[] args)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }

            if (IsSilent)
            {
                return true;
            }

            return ShowDialogCenterParent(
                (form, msg) =>
                {
                    DialogResult result = MessageBox.Show(
                        form,
                        msg,
                        Title,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);

                    return DialogResult.Yes == result;
                }, 
                value, 
                args);
        }

        private static void Show(MessageBoxIcon icon, object value, params object[] args)
        {
            ShowDialogCenterParent(
                (form, msg) =>
                {
                    MessageBox.Show(
                        form,
                        msg,
                        Title,
                        MessageBoxButtons.OK,
                        icon);

                    return false;
                },
                value,
                args);
        }

        private static bool ShowDialogCenterParent(Func<Form, string, bool> func, object value, params object[] args)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }

            string msg = string.Format(
                CultureInfo.CurrentCulture,
                value.ToString(),
                args);

            if (IsSilent)
            {
                throw new InvalidOperationException(msg);
            }

            IntPtr hwnd = App.MainWindowHandle;
            NativeMethods.RECT rect = new NativeMethods.RECT();
            NativeMethods.GetWindowRect(hwnd, out rect);

            using (Form form = new Form()
            {
                Opacity = 0,
                Width = 0,
                Height = 0,
                Left = rect.Left,
                Top = rect.Top,
                ShowInTaskbar = false,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                WindowState = FormWindowState.Minimized,
                StartPosition = FormStartPosition.Manual,
                TopMost = true,
            })
            {
                form.Show();
                return func(form, msg);
            }
        }

        private static class NativeMethods
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

            internal struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
        }
    }
}
