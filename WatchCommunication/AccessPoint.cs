using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WatchCommunication
{
    public class AccessPoint: IAccessPoint
    {
        public event Action<uint> OnPacketRecieved;
        public event Action OnLostConnection;

        private ISimpliciTIDriver simplicitiDriver;
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
        /// closing is a flag that is set by <see cref="Closed"/>, 
        /// read in <see cref="GetData"/> to determine whether to 
        /// end its infinite loop.
        /// </summary>
        private bool closing;
        /// <summary>
        /// The dirty flag is set by <see cref="GetData"/> if
        /// a timeout passes before the C111 responds to a data request.
        /// </summary>
        private bool dirty;
        /// <summary>
        /// Used for IsConnected. Set once the listen thread has started.
        /// </summary>
        private bool isOpen;

        public AccessPoint(ISimpliciTIDriver simplicitiDriver) {
            this.simplicitiDriver = simplicitiDriver;
            dirty = false;
            OnLostConnection += () => { };
            OnPacketRecieved += x => { };
            this.supervisorThread = new Thread(new ThreadStart(Supervisor));
            supervisorThread.IsBackground = true;
            supervisorThread.Start();
        }

        public bool IsConnected() {
            return isOpen;
        }

        public void Open() {
            if (!simplicitiDriver.PortOpen) {
                Initialize();
            }

            var ts = new ThreadStart(GetData);
            this.listenThread = new Thread(ts);
            listenThread.IsBackground = true;
            closing = false;
            listenThread.Start();
            isOpen = true;
        }

        /// <summary>
        /// Used by the supervisor thread. 
        /// </summary>
        private void Supervisor() {
            while (true) {
                if (dirty) {
                    OnLostConnection();
                    dirty = false;
                }
            }
        }

        public void Close() {
            closing = true;
            if (listenThread != null) 
                listenThread.Join();
            simplicitiDriver.CloseComPort();
            isOpen = false;
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
            while (!closing) {
                //Basically what we are doing here is spawning a new thread
                //for chronos.GetData. If it takes more than 1 second to come
                //back, we assume that the C111 was unplugged, so we kill the
                //thread and tell the supervisor that we are in trouble.
                var ts = new ThreadStart(() => {
                    completed = false;
                    simplicitiDriver.GetData(out data);
                    completed = true;
                });
                var t = new Thread(ts);
                t.IsBackground = true;
                t.Start();
                //need to strike a balance between false
                //positives and losing information
                t.Join(1500);
                if (completed) {
                    //255 is what the C111 sends back if it doesn't
                    //have any new data, so we ignore that
                    if (data != 255)
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
            var portName = simplicitiDriver.GetComPortName();
            if (portName.Length == 0)
                throw new AccessPointException();
            var open = simplicitiDriver.OpenComPort(portName);
            if (!open)
                throw new AccessPointException();
            var start = simplicitiDriver.StartSimpliciTI();
            if (!start)
                throw new AccessPointException();
        }
    }
}