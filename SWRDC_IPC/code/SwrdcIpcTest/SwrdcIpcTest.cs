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
            Thread server_thread = new Thread(GetacSwrdc.IpcTest.IpcTestClass.TestServer);
            server_thread.Start(5);
            Thread.Sleep(1000);

            Thread client_thread = new Thread(GetacSwrdc.IpcTest.IpcTestClass.TestClient);
            client_thread.Start(5);

            //while (true)
            {
                //GetacSwrdcUtil.DebugIt("Main", "waiting");
                Thread.Sleep(1000);
            }
        }

        public static void TestServer(object var)
        {
            int port = 9000;
            GetacSwrdc.IpcBase.IpcBaseClass ipc = new GetacSwrdc.IpcBase.IpcBaseClass { };
            GetacSwrdc.IpcApi.IpcApiClass ipc_api = ipc.IpcApi;

            int path_id = ipc_api.ApiTcpServer(port);
            if (path_id == -1)
            {
                return;
            }

 
            while (true)
            {
                string data = ipc_api.ApiTcpReceiveData(path_id);
                Utils.DebugClass.DebugIt("TestServer receive:", data);
                Thread.Sleep(1000);
            }
        }

        public static void TestClient(object var)
        {
            string ip_addr = "127.0.0.1";
            int port = 9000;

            GetacSwrdc.IpcBase.IpcBaseClass ipc = new GetacSwrdc.IpcBase.IpcBaseClass { };
            GetacSwrdc.IpcApi.IpcApiClass ipc_api = ipc.IpcApi;

            NetworkStream stream = ipc_api.ApiTcpClient(ip_addr, port);
            if (stream == null)
            {
                Utils.DebugClass.DebugIt("TestClient", "***** null stream");
                return;
            }

            Thread.Sleep(1000);
            for (int i = 0; i < 10; i++)
            {
                ipc_api.ApiTcpTransmitData(stream, "hello from phwang");
            }
        }
    }
}
