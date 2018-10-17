using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Getac.Csc.Utilities.Ipc
{
    class IpcApiClass
    {
        private IpcBaseClass IpcBase_;

        public IpcApiClass (IpcBaseClass base_var)
        {
            this.IpcBase_ = base_var;
        }

        public IpcBaseClass IpcBase()
        {
            return this.IpcBase_;
        }

        public IpcPathClass IpcPath ()
        {
            return this.IpcBase().IpcPath();
        }

        public IpcTcpClass IpcTcp()
        {
            return this.IpcBase().IpcTcp();
        }

        public int ApiTcpServer (int port_var)
        {
             int path_id = this.IpcTcp().TcpServer(port_var);
             return path_id;
        }

        public int ApiTcpClient (string ip_addr_var, int port_var)
        {
            int path_id = this.IpcTcp().TcpClient(ip_addr_var, port_var);
            return path_id;
        }

        public void ApiTcpTransmitData (int path_id_var, string data_var)
        {
            //Utils.DebugClass.DebugIt("ApiTcpTransmitData", data_var);
            this.IpcPath().TransmitData(path_id_var, data_var);
        }

        public string ApiTcpReceiveData (int path_id_var)
        {
             string data = this.IpcPath().ReceiveData(path_id_var);
            //Utils.DebugClass.DebugIt("ApiTcpReceiveData: data=", data);
            return data;
        }
    }
}

