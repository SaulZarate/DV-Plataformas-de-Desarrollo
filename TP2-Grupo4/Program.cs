using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Grupo4.Views;

using TP2_Grupo4.Models;

namespace TP2_Grupo4
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //foreach (Usuario usuario in Usuario.GetAll())
            //    System.Diagnostics.Debug.WriteLine(usuario.ToString());

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VistaLogin());
        }
    }
}
