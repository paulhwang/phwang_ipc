﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Getac.Swrdc
{
    class IpcTcpClass
    {
        private IpcBaseClass IpcBase_;

        public IpcTcpClass (IpcBaseClass base_var)
        {
            this.IpcBase_ = base_var;
        }

        public IpcBaseClass IpcBase()
        {
            return this.IpcBase_;
        }

        public IpcPathClass IpcPath()
        {
            return this.IpcBase().IpcPath();
        }

        public int TcpServer(int port_var)
        {
             TcpListener listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), port_var);
            listener.Start();
            //Utils.DebugClass.DebugIt("TcpServer", "after listener.Start()");

            TcpClient client = listener.AcceptTcpClient();
            //Utils.DebugClass.DebugIt("TcpServer", "after AcceptTcpClient");

            NetworkStream stream = client.GetStream();
            //Utils.DebugClass.DebugIt("TcpServer", "after GetStream");

            int path_id = this.IpcPath().AllocPath(stream);
            return path_id;
        }

        public int TcpClient(string ip_addr_var, int port_var)
        {
            //Utils.DebugClass.DebugIt("TcpClient", "start");
            TcpClient client = new TcpClient(ip_addr_var, port_var);
            NetworkStream stream = client.GetStream();
            //Utils.DebugClass.DebugIt("TcpClient", "end");

            int path_id = this.IpcPath().AllocPath(stream);
            return path_id;
        }

        public void TcpTransmitData(NetworkStream stream_var, string data_var)
        {
            BinaryWriter writer = new BinaryWriter(stream_var);
            writer.Write(data_var);
            writer.Flush();
        }

        string ReceivedData = null;

        public string TcpReceiveData(NetworkStream stream_var)
        {
            if (stream_var == null)
            {
                Utils.DebugClass.AbendIt("TCpReceiveData", "null stream_var");
                return null;
            }

            if (ReceivedData != null)
            {
                return ReceivedData;
            }

            ReceivedData = TcpReceiveData_(stream_var);
            string data = ReceivedData;
            ReceivedData = null;
            return data;
        }

        public string TcpReceiveData_(NetworkStream stream_var)
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
