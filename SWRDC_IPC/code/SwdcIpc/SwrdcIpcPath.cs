using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Getac.Swrdc.Ipc
{
    class IpcPathClass
    {
        private int PATH_ARRAY_LENGTH = 100;
        private IpcBaseClass IpcBase_;
        private IpcPathEntryClass[] PathEntryArray;

        public IpcPathClass (IpcBaseClass base_var)
        {
            this.IpcBase_ = base_var;
            this.PathEntryArray = new IpcPathEntryClass[this.PATH_ARRAY_LENGTH];
    }

    public IpcBaseClass IpcBase()
        {
            return this.IpcBase_;
        }

        public IpcTcpClass IpcTcp()
        {
            return this.IpcBase().IpcTcp();
        }

        public void TransmitData (int path_id_var, string data_var)
        {
            IpcPathEntryClass path_entry = GetPath(path_id_var);
            this.IpcTcp().TcpTransmitData(path_entry.TcpStream, data_var);
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

            string data = this.IpcTcp().TcpReceiveData(stream);
            return data;
        }

        private IpcPathEntryClass GetPath (int path_id_var)
        {
            if ((path_id_var < 0) || (this.PATH_ARRAY_LENGTH <= path_id_var))
            {
                return null;
            }
            return this.PathEntryArray[path_id_var];
        }

        public int AllocPath (NetworkStream stream_var)
        {
            
            IpcPathEntryClass path = new IpcPathEntryClass();
            path.TcpStream = stream_var;

            for (int i = 0; i < this.PATH_ARRAY_LENGTH; i++)
            {
                if (this.PathEntryArray[i] == null)
                {
                    this.PathEntryArray[i] = path;
                    return i;
                }
            }

            return -1;
        }

        public void FreePath (int path_id_var)
        {
            this.PathEntryArray[path_id_var] = null;
        }
    }

    class IpcPathEntryClass
    {
        public NetworkStream TcpStream;
        public string PathId;
    }

}
