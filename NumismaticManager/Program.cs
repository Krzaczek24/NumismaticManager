using NumismaticManager.Forms;
using System;
using System.Windows.Forms;

namespace NumismaticManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());

            PDF.PDFCreator.GenerateDoc(@"C:\Users\dremi\OneDrive\Pulpit\x\" + DateTime.Now.ToString("hh-mm-ss_dd-MM-yyyy") + ".pdf");
        }
    }
}
