using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fireasy.Windows.FormsTests
{
    static class Program
    {
        [DllImport("UxTheme.Dll", EntryPoint = "#65", CharSet = CharSet.Unicode)]
        public static extern int SetSystemVisualStyle(string pszFilename, string pszColor, string pszSize, int dwReserved);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SetSystemVisualStyle(@"C:\Windows\Resources\Themes\licorice\licorice10.msstyles", string.Empty, string.Empty, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TreeListForm());
        }
    }
}
