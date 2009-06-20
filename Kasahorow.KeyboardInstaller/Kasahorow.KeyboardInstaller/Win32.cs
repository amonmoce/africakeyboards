using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Kasahorow.KeyboardInstaller
{
    public class Win32
    {
        public const int WM_FONTCHANGE = 0x001D;
        public const int HWND_BROADCAST = 0xffff;

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, // handle to destination window
            uint Msg, // message
            int wParam, // first message parameter
            int lParam // second message parameter
        );

        [DllImport("gdi32")]
        public static extern int AddFontResource(string lpFileName);
    }
}
