﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BizTalkDeploymentTool
{
    public static class LogHelper
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        private static extern int SetWindowText(IntPtr hWnd, string text);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        public static void ShowMessage(string message = null, string title = null)
        {
            Process notepad = Process.Start(new ProcessStartInfo("notepad.exe"));
            notepad.WaitForInputIdle();

            if (!string.IsNullOrEmpty(title))
                SetWindowText(notepad.MainWindowHandle, title);

            if (notepad != null && !string.IsNullOrEmpty(message))
            {
                IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), "Edit", null);
                SendMessage(child, 0x000C, 0, message);
            }
        }
    }
}
