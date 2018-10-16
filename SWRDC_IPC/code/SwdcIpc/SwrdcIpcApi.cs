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
         private GetacSwrdc.IpcBase.IpcBaseClass IpcBase_;

        public IpcApiClass (GetacSwrdc.IpcBase.IpcBaseClass base_var)
        {
            this.IpcBase_ = base_var;
        }

        public IpcBase.IpcBaseClass IpcBase()
        {
            return this.IpcBase_;
        }

        public IpcPath.IpcPathClass IpcPath ()
        {
            return this.IpcBase().IpcPath();
        }

        public IpcTcp.IpcTcpClass IpcTcp()
        {
            return this.IpcBase().IpcTcp();
        }

        public int ApiTcpServer (int port_var)
        {
             int path_id = this.IpcTcp().TcpServer(port_var, this.IpcPath());
             return path_id;
        }

        public NetworkStream ApiTcpClient (string ip_addr_var, int port_var)
        {
            NetworkStream stream = this.IpcTcp().TcpClient(ip_addr_var, port_var);
            return stream;
        }

        public void ApiTcpTransmitData (NetworkStream stream_var, string data_var)
        {
            //Utils.DebugClass.DebugIt("ApiTcpTransmitData", data_var);
            this.IpcTcp().TcpTransmitData(stream_var, data_var);
        }

        public string ApiTcpReceiveData (int path_id_var)
        {
             string data = this.IpcPath().ReceiveData(path_id_var);
            //Utils.DebugClass.DebugIt("ApiTcpReceiveData: data=", data);
            return data;
        }
    }
}

