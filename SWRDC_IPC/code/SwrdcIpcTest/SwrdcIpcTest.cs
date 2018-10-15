using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetacSwrdc.IpcTest
{
    class IpcTestClass
    {
        public static void TestIpc ()
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

        public static void TestServer(object var)
        {
            int port = 9000;
            GetacSwrdc.IpcApi.IpcApiClass ipc_api = new GetacSwrdc.IpcApi.IpcApiClass { };

            NetworkStream stream = ipc_api.ApiTcpServer(port);
            if (stream == null)
            {
                return;
            }

            ipc_api.ApiTcpReceiveData(stream);
        }

        public static void TestClient(object var)
        {
            string ip_addr = "127.0.0.1";
            int port = 9000;
            GetacSwrdc.IpcApi.IpcApiClass ipc_api = new GetacSwrdc.IpcApi.IpcApiClass { };

            NetworkStream stream = ipc_api.ApiTcpClient(ip_addr, port);
            if (stream == null)
            {
                Utils.DebugClass.DebugIt("TestClient", "***** null stream");
                return;
            }

            Thread.Sleep(3000);
            ipc_api.ApiTcpTransmitData(stream, "hellp from phwang");
        }
    }
}
