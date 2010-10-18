using System;

namespace WatchCommunication
{
    /// <summary>
    /// A class that implements IAccessPoint encapsulates the connection
    /// between a watch and the computer. Objects of this class
    /// will close open COM port connections if they go out of scope.
    /// The default implementation is AccessPoint.
    /// </summary>
    public interface IAccessPoint: IDisposable
    {
        /// <summary>
        /// Called when a packet is recieved from a watch.
        /// It takes a single parameter, the data recieved.
        /// </summary>
        event Action<uint> OnPacketRecieved;
        /// <summary>
        /// Fires if the IAccessPoint loses its connection
        /// with the C111. Use with <see cref="TryRestart"/>
        /// to try to reconnect.
        /// <example>
        /// IAccessPoint ap = new AccessPoint();
        /// ap.OnLostConnection += new Action(() => {
        ///     //tell the user somehow about the problem
        ///     while (ap.TryRestart());
        /// });
        /// </example>
        /// </summary>
        event Action OnLostConnection;
        /// <summary>
        /// Starts a thread to listen to data recieved from COM port of 
        /// the C111. Every time data is recieved, the event 
        /// <see cref="OnPacketRecieved"/> is triggered. Multiple calls
        /// to <see cref=" Listen"/> without calling 
        /// <see cref="Close"/> in between is undefined behavior and 
        /// should be avoided.
        /// Throws an AccessPointException if cannot connect to C111
        /// or if cannot open SimpliciTI.
        /// Basically, if AccessPointException is thrown, then there is something
        /// physically wrong (e.g. access point not plugged in).
        /// </summary>
        void Open();
        /// <summary>
        /// Closes connection with C111.
        /// </summary>
        /// <summary>
        /// Returns whether the IAccesPoint is currently connected to a
        /// C111.
        /// </summary>
        bool IsConnected();
        void Close();
        /// <summary>
        /// Attempts to restart connection with C111. Instead of throwing
        /// an exception, it returns true if it could successfully reconnect,
        /// and false otherwise. <seealso cref="OnLostConnection"/>
        /// </summary>
        bool TryRestart();
    }

    public class AccessPointException: Exception { }
}