using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using WatchCommunication;
using Models;

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
            var watchPool = new WatchPool();
            var watchDataSaver = new WatchDataSaver(repository, watchPool, accessPoint);
            var gui = new Gui(repository, accessPoint, watchPool, watchDataSaver);
            Application.Run(gui);
        }
    }
