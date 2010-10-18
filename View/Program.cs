using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using WatchCommunication;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var repository = new NHibernateRepository(Configure.SQLite());
            var accessPoint = new AccessPoint();
            var gui = new Gui(repository, accessPoint);
            Application.Run(gui);
        }
    }
