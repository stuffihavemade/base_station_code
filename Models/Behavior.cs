using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Behavior : IBehavior
    {
        public virtual int Id { get; private set; }
        public virtual DateTime TimeRecorded { get; set; }
    }
}
