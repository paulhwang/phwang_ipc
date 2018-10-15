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
        private static void TestServer(object var)
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

        static void TestClient(object var)
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
