using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchCommunication;

    class Class1
    {
        public static void Main(string[] args) {
            IAccessPoint a = new AccessPoint();
            a.OnPacketRecieved += new Action<uint>(a_OnPacketRecieved);
            a.OnLostConnection += new Action(() => {
                Console.WriteLine("lost connection");
                while (!a.TryRestart()) ;
            });
            a.Open();
            IAccessPoint b = new AccessPoint();
            b.OnPacketRecieved += new Action<uint>((x) => Console.Write("hi"));
        }

        static void a_OnPacketRecieved(uint obj) {
            Console.WriteLine(obj);
        }
    }

