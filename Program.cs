using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitTrack_DDOCP.Forms;

namespace FitTrack_DDOCP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Authentication authForm = new Authentication();
            DialogResult result = authForm.ShowDialog();
            
            if (result == DialogResult.OK && authForm.LoggedInUser != null)
            {
                Application.Run(new MainDashboard(authForm.LoggedInUser.Username));
            }
        }
    }
}
