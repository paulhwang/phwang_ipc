using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GetacSwrdc.IpcCore
{
    class IpcCoreClass
    {
        public NetworkStream TcpServer(int port_var)
        {
 
            TcpListener listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), port_var);
            listener.Start();
            //Utils.DebugClass.DebugIt("TcpServer", "after listener.Start()");

            TcpClient client = listener.AcceptTcpClient();
            //Utils.DebugClass.DebugIt("TcpServer", "after AcceptTcpClient");

            NetworkStream stream = client.GetStream();
            //Utils.DebugClass.DebugIt("TcpServer", "after GetStream");

             return stream;
        }

        public NetworkStream TcpClient(string ip_addr_var, int port_var)
        {
            //Utils.DebugClass.DebugIt("TcpClient", "start");
            TcpClient client = new TcpClient(ip_addr_var, port_var);
            NetworkStream stream = client.GetStream();
            //Utils.DebugClass.DebugIt("TcpClient", "end");
            return stream;
        }

        public void TcpTransmitData(NetworkStream stream_var, string data_var)
        {
            BinaryWriter writer = new BinaryWriter(stream_var);
            writer.Write(data_var);
            writer.Flush();
        }

        string ReceivedData = null;

        public string TCpReceiveData(NetworkStream stream_var)
        {
            if (ReceivedData != null)
            {
                return ReceivedData;
            }

            ReceivedData = TCpReceiveData_(stream_var);
            string data = ReceivedData;
            ReceivedData = null;
            return data;
        }

        public string TCpReceiveData_(NetworkStream stream_var)
        {
            BinaryReader reader = new BinaryReader(stream_var);

            try
            {
                string data = reader.ReadString();
                //Utils.DebugClass.DebugIt("TCpReceiveData: data=", data);
                return data;
            }
            catch (Exception ex)
            {
                Utils.DebugClass.DebugIt("TCpReceiveData", "exception");
                return null;
            }
        }
    }
}
