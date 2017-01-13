using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Fireasy.Windows
{
    internal static class NativeMethods
    {
        // Constants.
        // Copied from winuser.h

        public const int WM_CLOSE = 0x10;
        public const int WM_COMMAND = 0x111;

        public const string CLS_BUTTON = "BUTTON";
        public const string CLS_STATIC = "STATIC";

        public const int SS_ICON = 3;

        public const int GWL_STYLE = -16;
        public const int GWL_ID = -12;

        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020; /* The frame changed: send WM_NCCALCSIZE */
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOOWNERZORDER = 0x0200;  /* Don't do owner Z ordering */
        public const int SWP_NOSENDCHANGING = 0x0400; /* Don't send WM_WINDOWPOSCHANGING */

        //  Dialog Box Command IDs
        public const int IDOK = 1;
        public const int IDCANCEL = 2;
        public const int IDABORT = 3;
        public const int IDRETRY = 4;
        public const int IDIGNORE = 5;
        public const int IDYES = 6;
        public const int IDNO = 7;
        public const int IDCLOSE = 8;
        public const int IDHELP = 9;
        public const int IDTRYAGAIN = 10;
        public const int IDCONTINUE = 11;

        // Button notification code
        public const int BN_CLICKED = 0;

        // Methods
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hWnd, string text);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr FindWindow(string className, string caption);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string className, string caption);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int GetWindowLong(IntPtr hWnd, int index);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetWindowLong(IntPtr hWnd, int index, IntPtr newLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc callback, IntPtr param);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder className, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, [In, Out] ref NativeMethods.RECT rect);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetClientRect(IntPtr hWnd, [In, Out] ref NativeMethods.RECT rect);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, [In, Out] ref NativeMethods.POINT point);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool DestroyWindow(IntPtr hWnd);


        public static IntPtr MakeWParam(int lowWord, int highWord)
        {
            int wparam = highWord << 16;
            wparam |= (lowWord & 0xffff);

            return new IntPtr(wparam);

        }

        // structs

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public RECT(Rectangle r)
            {
                this.left = r.Left;
                this.top = r.Top;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            public static NativeMethods.RECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethods.RECT(x, y, x + width, y + height);
            }

            public Size Size
            {
                get
                {
                    return new Size(this.right - this.left, this.bottom - this.top);
                }
            }

            public override string ToString()
            {
                return string.Format("{0},{1},{2},{3}", this.left, this.top, this.right - this.left, this.bottom - this.top);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;
        }

        // delegates

        internal delegate bool EnumChildProc(IntPtr hWnd, IntPtr param);

    }
}
