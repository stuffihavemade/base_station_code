using WatchCommunication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Rhino.Mocks;

namespace WatchCommunicationTests
{


    /// <summary>
    ///This is a test class for AccessPointTest and is intended
    ///to contain all AccessPointTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccessPointTest
    {
        private ISimpliciTIDriver mockSimplicitiDriver;
        private AccessPoint accessPoint;

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void TestInitialize()
        {
            mockSimplicitiDriver = MockRepository.GenerateStub<ISimpliciTIDriver>();
            accessPoint = new AccessPoint(mockSimplicitiDriver);

        }

        [TestMethod()]
        [ExpectedException(typeof(AccessPointException))]
        public void CannotFindCOMPortTest()
        {
            mockSimplicitiDriver.Expect(m => m.PortOpen).Return(false);
            mockSimplicitiDriver.Stub(m => m.GetComPortName()).Return("");
            accessPoint.Open();
        }

        [TestMethod()]
        [ExpectedException(typeof(AccessPointException))]
        public void CannotOpenTest()
        {
            mockSimplicitiDriver.Expect(m => m.PortOpen).Return(false);
            mockSimplicitiDriver.Stub(m => m.GetComPortName()).Return("COM0");
            accessPoint.Open();
        }

        [TestMethod()]
        [ExpectedException(typeof(AccessPointException))]
        public void CannotStartSimpliciTITest()
        {
            mockSimplicitiDriver.Expect(m => m.PortOpen).Return(false);
            mockSimplicitiDriver.Stub(m => m.GetComPortName()).Return("COM0");
            mockSimplicitiDriver.Expect(m => m.StartSimpliciTI()).Return(false);
            accessPoint.Open();
        }

        [TestMethod()]
        public void IsConnectedTest()
        {
            mockSimplicitiDriver.Expect(m => m.PortOpen).Return(true);
            accessPoint.Open();
            Assert.AreEqual<bool>(accessPoint.IsConnected(), true);
        }

        //[TestMethod()]
        //public void PacketRecievedTest()
        //{
        //    mockSimplicitiDriver.Expect(m => m.PortOpen).Return(true);

        //    mockSimplicitiDriver.Stub(m => m.GetData(out 0)).IgnoreArguments().OutRef(1);
        //    bool recieved = false;
        //    accessPoint.OnPacketRecieved += (d) => { recieved = true; };
        //    accessPoint.Open();
        //    while (recieved == false) { };
        //    Assert.AreEqual<bool>(true, true);
        //}
    }

}
