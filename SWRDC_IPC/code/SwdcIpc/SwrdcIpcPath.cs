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
        private IpcTcp.IpcCoreClass ipc_core = new IpcTcp.IpcCoreClass();

        void TransmitData (int path_id_var, string data_var)
        {
            IpcPathEntryClass path_entry = GetPath(path_id_var);
            ipc_core.TcpTransmitData(path_entry.TcpStream, data_var);
        }

        string ReceiveData (int path_id_var)
        {
            IpcPathEntryClass path_entry = GetPath(path_id_var);
            string data = ipc_core.TCpReceiveData(path_entry.TcpStream);
            return null;
        }

        IpcPathEntryClass GetPath (int path_id_var)
        {
            return null;
        }

        int AllocPath ()
        {
            return 1;
        }

        void freePath (int path_id_var)
        {

        }
    }

    class IpcPathEntryClass
    {
        public NetworkStream TcpStream;
    }

}
