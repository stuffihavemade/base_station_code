using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eZ430ChronosNet;

namespace WatchCommunication
{
    public class SimpliciTIDriver: ISimpliciTIDriver
    {
        private Chronos chronos;

        public SimpliciTIDriver() {
            this.chronos = new Chronos();
        }

        public bool PortOpen {
            get { return chronos.PortOpen; }
        }

        public bool OpenComPort(string portName) {
            return chronos.OpenComPort(portName);
        }

        public void CloseComPort() {
            chronos.CloseComPort();
        }

        public string GetComPortName() {
            return chronos.GetComPortName();
        }

        public bool GetData(out uint data) {
            return chronos.GetData(out data);
        }

        public bool StartSimpliciTI() {
            return chronos.StartSimpliciTI();
        }

        public bool StopSimpliciTI() {
            return chronos.StartSimpliciTI();
        }
    }
}
