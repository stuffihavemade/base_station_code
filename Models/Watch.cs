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
        public uint PacketIdentifier {get; set;}
        public Student Student { get; set; }

    }
}
