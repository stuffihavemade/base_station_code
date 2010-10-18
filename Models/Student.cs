using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Models
{
    public class Student
    {
        //virtuals for NHibernate
        public virtual int Id { get; private set; }
        private string _firstName;
        public virtual string FirstName {
            get { return _firstName; }
            private set {
                if (value.Length > 0)
                    _firstName = value;
                else
                    throw new ArgumentException("First name is required.");
            }
        }
        private string _lastName;
        public virtual string LastName {
            get { return _lastName; }
            private set {
                if (value.Length > 0)
                    _lastName = value;
                else
                    throw new ArgumentException("Last name is required.");
            }
        }
        private string _teacher;
        public virtual string Teacher {
            get { return _teacher; }
            private set {
                if (value.Length > 0)
                    _teacher = value;
                else
                    throw new ArgumentException("Teacher is required.");
            }
        }
        private string _behaviorName;
        public virtual string BehaviorName {
            get { return _behaviorName; }
            private set {
                if (value.Length > 0)
                    _behaviorName = value;
                else
                    throw new ArgumentException("The name of the behavior is required.");
            }
        }
        public virtual IList<Behavior> Behaviors { get; set; }


        public Student(string firstName, string lastName,
                       string teacher, string behaviorName,
                       IList<Behavior> behaviors) {
            FirstName = firstName;
            LastName = lastName;
            Teacher = teacher;
            BehaviorName = behaviorName;
            Behaviors = behaviors;
        }

        public override string ToString() {
            return this.FirstName + " " + this.LastName;
        }
        /// <summary>
        /// This is only for NHibernate. You can't actually
        /// do anything with it.
        /// </summary>
        public Student() { }
    }
}
