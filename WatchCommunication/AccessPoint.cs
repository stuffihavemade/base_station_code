﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eZ430ChronosNet;
using System.Threading;

namespace WatchCommunication
{
    public class AccessPoint: IAccessPoint
    {
        public event Action<uint> OnPacketRecieved;
        public event Action OnLostConnection;

        private Chronos chronos;
        /// <summary>
        /// The listen thread listens for data from the C111.
        /// </summary>
        private Thread listenThread;
        /// <summary>
        /// The supervisor thread is a seperate thread that listens
        /// for a change to dirty. The reason that it is in a seperate
        /// thread instead of being incorporated into listen is that if
        /// there is a problem, we want to kill listen completetely instead
        /// of comming back. Actually, just trust me, this is the best way
        /// to do it.
        /// </summary>
        private Thread supervisorThread;
        /// <summary>
        /// closed is a flag that is set by <see cref="Closed"/>, 
        /// read in <see cref="GetData"/> to determine whether to 
        /// end its infinite loop.
        /// </summary>
        private bool closed;
        /// <summary>
        /// The dirty flag is set by <see cref="GetData"/> if
        /// a timeout passes before the C111 responds to a data request.
        /// </summary>
        private bool dirty;

        public AccessPoint() {
            this.chronos = new Chronos();
            dirty = false;
            this.supervisorThread = new Thread(new ThreadStart(Supervisor));
            supervisorThread.Start();
        }

        public void Open() {
            if (!chronos.PortOpen) {
                Initialize();
            }

            var ts = new ThreadStart(GetData);
            this.listenThread = new Thread(ts);
            closed = false;
            listenThread.Start();
        }

        /// <summary>
        /// Used by the supervisor thread. 
        /// </summary>
        private void Supervisor() {
            while (true) {
                if (dirty && OnLostConnection != null) {
                    OnLostConnection();
                    dirty = false;
                }
            }
        }

        public void Close() {
            closed = true;
            listenThread.Join();
            chronos.CloseComPort();
        }

        public bool TryRestart() {
            try {
                Close();
                Open();
                return true;
            }
            catch {
                return false;
            }
        }

        public void Dispose() {
            Close();
        }

        private void GetData() {
            uint data = 0;
            var completed = false;
            while (!closed) {
                //Basically what we are doing here is spawning a new thread
                //for chronos.GetData. If it takes more than 1 second to come
                //back, we assume that the C111 was unplugged, so we kill the
                //thread and tell the supervisor that we are in trouble.
                var ts = new ThreadStart(() => {
                    completed = false;
                    chronos.GetData(out data);
                    completed = true;
                });
                var t = new Thread(ts);
                t.Start();
                //waits for 1 second before timing out 
                t.Join(1000);
                if (completed) {
                    //255 is what the C111 sends back if it doesn't
                    //have any new data, so we ignore that
                    if (data != 255 && OnPacketRecieved != null)
                        OnPacketRecieved(data);
                }
                else {
                    t.Abort();
                    dirty = true;
                    break;
                }
            }
        }

        private void Initialize() {
            var portName = chronos.GetComPortName();
            if (portName.Length == 0)
                throw new AccessPointException();
            var open = chronos.OpenComPort(portName);
            if (!open)
                throw new AccessPointException();
            var start = chronos.StartSimpliciTI();
            if (!start)
                throw new AccessPointException();
        }
    }
}