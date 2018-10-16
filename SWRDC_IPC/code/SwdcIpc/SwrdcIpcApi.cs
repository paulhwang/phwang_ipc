using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GetacSwrdc.IpcApi
{
    class IpcApiClass
    {
        private IpcTcp.IpcCoreClass ipc_core = new IpcTcp.IpcCoreClass();

        public NetworkStream ApiTcpServer(int port_var)
        {
             NetworkStream stream = ipc_core.TcpServer(port_var);
             return stream;
        }

        public NetworkStream ApiTcpClient(string ip_addr_var, int port_var)
        {
            NetworkStream stream = ipc_core.TcpClient(ip_addr_var, port_var);
            return stream;
        }

        public void ApiTcpTransmitData(NetworkStream stream_var, string data_var)
        {
            //Utils.DebugClass.DebugIt("ApiTcpTransmitData", data_var);
            ipc_core.TcpTransmitData(stream_var, data_var);
        }

        public string ApiTcpReceiveData(NetworkStream stream_var)
        {
            string data = ipc_core.TCpReceiveData(stream_var);
            //Utils.DebugClass.DebugIt("ApiTcpReceiveData", data_var);
            return data;
        }
    }
}

