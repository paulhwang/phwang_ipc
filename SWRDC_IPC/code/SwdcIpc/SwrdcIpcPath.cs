using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GetacSwrdc.IpcPath
{
    class IpcPathClass
    {
        private IpcTcp.IpcTcpClass ipc_core = new IpcTcp.IpcTcpClass { };
        private IpcPathEntryClass path_entry1 = new IpcPathEntryClass { };

        public void TransmitData (int path_id_var, string data_var)
        {
            IpcPathEntryClass path_entry = GetPath(path_id_var);
            ipc_core.TcpTransmitData(path_entry.TcpStream, data_var);
        }

        public string ReceiveData (int path_id_var)
        {
            IpcPathEntryClass path_entry = GetPath(path_id_var);
            if (path_entry == null)
            {
                Utils.DebugClass.AbendIt("ReceiveData", "null path_entry");
                return null;
            }

            NetworkStream stream = path_entry.TcpStream;
            if (stream == null)
            {
                Utils.DebugClass.AbendIt("ReceiveData", "null stream");
                return null;
            }

            string data = ipc_core.TcpReceiveData(stream);
            return data;
        }

        private IpcPathEntryClass GetPath (int path_id_var)
        {
             return path_entry1;
        }

        public int AllocPath (NetworkStream stream_var)
        {
            path_entry1.TcpStream = stream_var;
            path_entry1.PathId = "100";
 
            return 1;
        }

        public void freePath (int path_id_var)
        {

        }
    }

    class IpcPathEntryClass
    {
        public NetworkStream TcpStream;
        public string PathId;
    }

}
