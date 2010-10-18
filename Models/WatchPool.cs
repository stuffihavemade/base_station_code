using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class WatchPool: List<Watch>
    {

        public bool HasWatchWithIdentifier(uint packetIdentifier) {
            var num = this.Where(w => w.PacketIdentifier == packetIdentifier)
                .Count();
            if (num > 0)
                return true;
            else
                return false;
        }

        public Watch WithIdentifier(uint packetIdentifier) {
            try {
                return this.Where(w => w.PacketIdentifier == packetIdentifier)
                    .First();
            }
            catch {
                throw new WatchDoesNotExistException();
            }
        }

    }
    public class WatchDoesNotExistException: Exception { }
}