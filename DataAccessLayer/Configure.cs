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
        public static void Main (string[] args) {
            var a = Configure.SQLite();
            var b = a.OpenSession();
            var cr = b.BeginTransaction();
            var l = new List<Behavior>();
            var s = new Student();
            s.Behaviors = new List<Behavior>();
            s.Behaviors.Add(new Behavior { TimeRecorded = DateTime.Now });
            s.Behaviors.Add(new Behavior { TimeRecorded = DateTime.Now });
            s.FirstName = "E";
            s.LastName = "R";
            s.Teacher = "T";
            b.Save(s);
            cr.Commit();
            var e = b.CreateCriteria<Student>().Add(NHibernate.Criterion.Restrictions.Eq("FirstName", "E")).List<Student>();
            b.Close();
            var re = new NHibernateRepository<Student>(a);
            var z = re.AllOfStudent("E", "R");
            
            var cc = 1;
        }

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
