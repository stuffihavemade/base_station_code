using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class WatchPool : Models.IWatchPool
    {
        private IList<Watch> Collection {get; set;}

        public WatchPool() {
            Collection = new List<Watch>();
        }

        /// <summary>
        /// Throws an exception if a previously added watch
        /// is added again.
        /// </summary>
        /// <param name="watch"></param>
        public void AddWatch(Watch watch) {
            var exists = Collection.Any(w => w.PacketIdentifier == watch.PacketIdentifier);
            if (exists)
                throw new WatchExistsException();
            else
                Collection.Add(watch);
        }

        public bool HasWatchWithIdentifier(uint packetIdentifier) {
            var num = Collection.Where(w => w.PacketIdentifier == packetIdentifier)
                .Count();
            if (num > 0)
                return true;
            else
                return false;
        }

        public void UnpairWatchWithStudent(Student student) {
            try {
                this.WatchPairedWith(student).Unpair();
            }
            catch (WatchExistsException) { }
        }

        public void UnpairWatchesWithStudents(IEnumerable<Student> students) {
            foreach (var s in students)
                UnpairWatchWithStudent(s);
        }

        public Watch WatchPairedWith(Student student) {
            try {
                return Collection.Where(w => w.Student.Id == student.Id).First();
            }
            catch {
                throw new WatchDoesNotExistException();
            }
        }

        public IList<Student> StudentsWithWatches() {
            return Collection.Where(w => w.IsPaired()).Select(w => w.Student).ToList();
        }

        public IList<Watch> AvailableWatches() {
            return Collection.Where(w => !w.IsPaired()).ToList();
        }

        public Watch WatchWithIdentifier(uint packetIdentifier) {
            try {
                return Collection.Where(w => w.PacketIdentifier == packetIdentifier).First();
            }
            catch {
                throw new WatchDoesNotExistException();
            }
        }

    }
}