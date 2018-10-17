using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Getac.Csc.Util.Ipc
{
    class IpAddrPort
    {
        public string IpAddr;
        public int Port;

        public IpAddrPort(string ip_addr_var, int port_var)
        {
            this.IpAddr = ip_addr_var;
            this.Port = port_var;
        }
    }
    class IpcTestClass
    {
        public static void TestIpc (string ip_addr_var, int port_var)
        {
            Thread server_thread = new Thread(IpcTestClass.RunAsServer);
            server_thread.Start(new IpAddrPort("127.0.0.1", 9000));
            Thread.Sleep(1000);

            Thread client_thread = new Thread(IpcTestClass.RunAsClient);
            client_thread.Start(new IpAddrPort("127.0.0.1", 9000));

            //while (true)
            {
                //GetacSwrdcUtil.DebugIt("Main", "waiting");
                Thread.Sleep(1000);
            }
        }

        public static void RunAsServer(object ip_addr_port_var)
        {
            IpAddrPort ip_addr_port = (IpAddrPort)ip_addr_port_var;

            Getac.Csc.Utilities.Ipc.IpcBaseClass ipc_base = new Getac.Csc.Utilities.Ipc.IpcBaseClass();
            Getac.Csc.Utilities.Ipc.IpcApiClass ipc_api = ipc_base.IpcApi();

            int path_id = ipc_api.ApiTcpServer(ip_addr_port.IpAddr, ip_addr_port.Port);
            if (path_id == -1)
            {
                return;
            }
 
            while (true)
            {
                string data = ipc_api.ApiTcpReceiveData(path_id);
                Utilities.DebugClass.DebugIt("TestServer receive:", data);
                //Thread.Sleep(100);
            }
        }

        public static void RunAsClient(object ip_addr_port_var)
        {
            IpAddrPort ip_addr_port = (IpAddrPort)ip_addr_port_var;

            Getac.Csc.Utilities.Ipc.IpcBaseClass ipc_base = new Getac.Csc.Utilities.Ipc.IpcBaseClass();
            Getac.Csc.Utilities.Ipc.IpcApiClass ipc_api = ipc_base.IpcApi();

            int path_id = ipc_api.ApiTcpClient(ip_addr_port.IpAddr, ip_addr_port.Port);
            if (path_id == -1)
            {
                Utilities.DebugClass.DebugIt("TestClient", "***** path_id == -1");
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
