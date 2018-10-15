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
        private IpcCore.IpcCoreClass ipc_core = new IpcCore.IpcCoreClass();

        public NetworkStream ApiTcpServer(int port_var)
        {
            Utils.DebugClass.DebugIt("ApiTcpServer", "start");
            NetworkStream stream = ipc_core.TcpServer(port_var);
            Utils.DebugClass.DebugIt("ApiTcpServer", "end");
            return stream;
        }

        public NetworkStream ApiTcpClient(string ip_addr_var, int port_var)
        {
            Utils.DebugClass.DebugIt("ApiTcpClient", "start");
            NetworkStream stream = ipc_core.TcpClient(ip_addr_var, port_var);
            Utils.DebugClass.DebugIt("ApiTcpClient", "end");
            return stream;
        }

        public void ApiTcpTransmitData(NetworkStream stream_var, string data_var)
        {
            Utils.DebugClass.DebugIt("ApiTcpTransmitData", "start");
            Utils.DebugClass.DebugIt("ApiTcpTransmitData", data_var);
            ipc_core.TcpTransmitData(stream_var, data_var);
            Utils.DebugClass.DebugIt("ApiTcpTransmitData", "end");
        }

        public void ApiTcpReceiveData(NetworkStream stream_var)
        {
            Utils.DebugClass.DebugIt("ApiTcpReceiveData", "start");
            ipc_core.TCpReceiveData(stream_var);
            Utils.DebugClass.DebugIt("ApiTcpReceiveData", "end");

        }
    }
}

