using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using WatchCommunication;
using SpreadsheetExport;
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
            var accessPoint = new AccessPoint(new SimpliciTIDriver());
            var watchPool = new WatchPool();
            var watchDataSaver = new WatchDataSaver(repository, watchPool, accessPoint);
            var excelCreator = new SpreadsheetExporter();
            var gui = new Gui(repository, accessPoint, watchPool, watchDataSaver, excelCreator);
            Application.Run(gui);
        }
    }
