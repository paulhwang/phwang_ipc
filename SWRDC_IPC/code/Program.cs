using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetacSwrdc
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.DebugClass.DebugIt("Main", "start");

            Thread server_thread = new Thread(GetacSwrdc.IpcTest.IpcTestClass.TestServer);
            server_thread.Start(5);
            Thread.Sleep(3000);

            Thread client_thread = new Thread(GetacSwrdc.IpcTest.IpcTestClass.TestClient);
            client_thread.Start(5);

            //while (true)
            {
                //GetacSwrdcUtil.DebugIt("Main", "waiting");
                Thread.Sleep(1000);
            }

            Utils.DebugClass.DebugIt("Main", "end");
        }
    }
}
