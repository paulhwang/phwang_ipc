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
        private IpcTcp.IpcTcpClass ipc_core = new IpcTcp.IpcTcpClass { };
        private IpcPath.IpcPathClass ipc_path = new IpcPath.IpcPathClass { };

        public int ApiTcpServer(int port_var)
        {
             int path_id = ipc_core.TcpServer(port_var, ipc_path);
             return path_id;
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

        public string ApiTcpReceiveData(int path_id_var)
        {
             string data = ipc_path.ReceiveData(path_id_var);
            //Utils.DebugClass.DebugIt("ApiTcpReceiveData: data=", data);
            return data;
        }
    }
}

