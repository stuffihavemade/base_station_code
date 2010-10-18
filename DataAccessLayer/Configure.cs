using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Models;

namespace DataAccessLayer
{
    public class Configure
    {
        public static ISessionFactory SQLite() {
            return Fluently.Configure()
            .Database(SQLiteConfiguration.Standard.UsingFile("database.db"))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BehaviorMap>())
            .ExposeConfiguration(c => {
                if (!System.IO.File.Exists("database.db"))
                    new SchemaExport(c).Create(false, true);
            })
            .BuildSessionFactory();
        }
    }
}
