using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class WatchPool
    {
        private List<Watch> watches;

        public WatchPool() {
            watches = new List<Watch>();
        }

        public void Add(Watch watch) {
            watches.Add(watch);
        }

        public bool HasWatchWithIdentifier(uint packetIdentifier) {
            var num = watches.Where(w => w.PacketIdentifier == packetIdentifier)
                .Count();
            if (num > 0)
                return true;
            else
                return false;
        }


        public Watch WithIdentifier(uint packetIdentifier) {
            try {
                return watches.Where(w => w.PacketIdentifier == packetIdentifier)
                    .First();
            }
            catch {
                throw new WatchDoesNotExistException();
            }
        }

    }
    public class WatchDoesNotExistException: Exception { }
}