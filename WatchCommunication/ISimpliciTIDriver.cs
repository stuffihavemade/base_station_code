using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WatchCommunication
{
    /// <summary>
    /// This interface is provides a very thin wrapper to the library we are 
    /// using to talk to the access point. This allows to mock out the library
    /// and test the threading logic in <see cref="AccessPoint"/>. The default implementation
    /// is <see cref="SimpliciTIDriver"/>.
    /// </summary>
    public interface ISimpliciTIDriver
    {
        bool PortOpen { get; }
        bool OpenComPort(string portName);
        void CloseComPort();
        string GetComPortName();
        /// <summary>
        /// The CC1111 constantly outputs data. If no new packets have been 
        /// recieved, data will be set to 255. So, to make sure no data is
        /// missed, GetData must run constantly in a loop (polling, not 
        /// interrupt based).
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool GetData(out uint data);
        bool StartSimpliciTI();
        bool StopSimpliciTI();
    }
}
