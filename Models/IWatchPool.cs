using System;
namespace Models
{
    /// <summary>
    /// Classes that implement this interface encapsulate the idea of 
    /// a collection of watches, and various actions that can
    /// be used on such a collection. The included implementation
    /// is <see cref="WatchPool"/>.
    /// </summary>
    public interface IWatchPool
    {
        /// <summary>
        /// Add a watch to the watch pool. Throws a 
        /// WatchExistsException if the watch
        /// already exists in this pool.
        /// </summary>
        /// <param name="watch"></param>
        void AddWatch(Watch watch);
        /// <summary>
        /// Return all watches that are not assigned to a student.
        /// </summary>
        System.Collections.Generic.IList<Watch> AvailableWatches();
        /// <summary>
        /// Return whether this watch pool has a watch that is sending
        /// packet data equal to packetIdentifier.
        /// </summary>
        bool HasWatchWithIdentifier(uint packetIdentifier);
        /// <summary>
        /// Return all students that are paired with watches in this
        /// watch pool.
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.IList<Student> StudentsWithWatches();
        /// <summary>
        /// Return the watch paired with this student. Throws
        /// an WatchDoesNotExistException if no such watch exists.
        /// </summary>
        Watch WatchPairedWith(Student student);
        /// <summary>
        /// Return the  watch that is sending packet data
        /// equal to packetIdentifier. Throws an 
        /// WatchDoesNotExistException if no such watch
        /// exists.
        /// </summary>
        Watch WatchWithIdentifier(uint packetIdentifier);
    }
    public class WatchDoesNotExistException: Exception { }
    public class WatchExistsException: Exception { }
}
