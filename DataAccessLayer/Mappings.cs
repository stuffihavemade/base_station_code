using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using FluentNHibernate.Mapping;

namespace DataAccessLayer
{
    public class StudentMap: ClassMap<Student>
    {
        public StudentMap() {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Teacher);
            HasMany<Behavior>(x => x.Behaviors)
                .Cascade.All();
        }
    }

    public class BehaviorMap: ClassMap<Behavior>
    {
        public BehaviorMap() {
            Id(x => x.Id);
            Map(x => x.TimeRecorded);
        }
    }
}
