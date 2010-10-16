using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Student : IStudent
    {
        //TODO: add validation to properties
        //virtual for NHibernate
        public virtual int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName  { get; set; }
        public virtual string Teacher   { get; set; }
        public virtual IList<Behavior> Behaviors { get; set; }
    }
}
