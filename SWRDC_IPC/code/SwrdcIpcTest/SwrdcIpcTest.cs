using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Getac.Csc.Util.Test
{
    class IpcTestClass
    {
        public static void TestIpc ()
        {
            Thread server_thread = new Thread(IpcTestClass.TestServer);
            server_thread.Start(5);
            Thread.Sleep(1000);

            Thread client_thread = new Thread(IpcTestClass.TestClient);
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
            Getac.Csc.Util.Ipc.IpcBaseClass ipc_base = new Getac.Csc.Util.Ipc.IpcBaseClass();
            Getac.Csc.Util.Ipc.IpcApiClass ipc_api = ipc_base.IpcApi();

            int path_id = ipc_api.ApiTcpServer(port);
            if (path_id == -1)
            {
                return;
            }
 
            while (true)
            {
                string data = ipc_api.ApiTcpReceiveData(path_id);
                Util.DebugClass.DebugIt("TestServer receive:", data);
                //Thread.Sleep(100);
            }
        }

        public static void TestClient(object var)
        {
            string ip_addr = "127.0.0.1";
            int port = 9000;

            Getac.Csc.Util.Ipc.IpcBaseClass ipc_base = new Getac.Csc.Util.Ipc.IpcBaseClass();
            Getac.Csc.Util.Ipc.IpcApiClass ipc_api = ipc_base.IpcApi();

            int path_id = ipc_api.ApiTcpClient(ip_addr, port);
            if (path_id == -1)
            {
                Util.DebugClass.DebugIt("TestClient", "***** path_id == -1");
                return;
            }

            Thread.Sleep(1000);
            for (int i = 0; i < 5; i++)
            {
                ipc_api.ApiTcpTransmitData(path_id, "hello from phwang");
            }
        }
    }
}
