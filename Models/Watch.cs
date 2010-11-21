using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Watch
    {
        /// <summary>
        /// Data recieved from watch. Assumed to be unique
        /// for each watch.
        /// </summary>
        public uint PacketIdentifier { get; set; }
        public Student Student { get; private set; }

        public void PairWith(Student student) {
            Student = student;
        }

        public void Unpair() {
            Student = null;
        }

        public void RecordBehavior(Behavior behavior) {
            Student.CommitedBehavior(behavior);
        }

        public bool IsPaired() {
            if (Student == null)
                return false;
            else
                return true;

        }

        public override string ToString() {
            return "Available Watch";
        }
    }
}