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
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Teacher).Not.Nullable();
            Map(x => x.BehaviorName).Not.Nullable();
            HasMany<Behavior>(x => x.Behaviors)
                .Cascade.All();
        }
    }


    public class BehaviorMap: ClassMap<Behavior>
    {
        public BehaviorMap() {
            Id(x => x.Id);
            Map(x => x.TimeRecorded).Not.Nullable();
        }
    }
}
