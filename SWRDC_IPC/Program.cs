﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWRDC_IPC
{
    class Program
    {
        static void Main(string[] args)
        {
            GetacSwrdcUtil.DebugIt("Main", "start");

            Thread server_thread = new Thread(TestServer);
            server_thread.Start(5);
            Thread.Sleep(3000);

            Thread client_thread = new Thread(TestClient);
            client_thread.Start(5);

            //while (true)
            {
                //GetacSwrdcUtil.DebugIt("Main", "waiting");
                Thread.Sleep(1000);
            }

            GetacSwrdcUtil.DebugIt("Main", "end");
        }

        private static void TestServer (object var)
        {
            int port = 9000;
            GetacSwrdcIpcApi ipc_api = new GetacSwrdcIpcApi {};

            NetworkStream stream = ipc_api.ApiTcpServer(port);
            if (stream == null)
            {
                return;
            }

            ipc_api.ApiTcpReceiveData(stream);
        }

        static void TestClient (object var)
        {
            string ip_addr = "127.0.0.1";
            int port = 9000;
            GetacSwrdcIpcApi ipc_api = new GetacSwrdcIpcApi {};

            NetworkStream stream = ipc_api.ApiTcpClient(ip_addr, port);
            if (stream == null)
            {
                GetacSwrdcUtil.DebugIt("TestClient", "***** null stream");
                return;
            }

            Thread.Sleep(3000);
            ipc_api.ApiTcpTransmitData(stream, "hellp from phwang");
        }
    }

    class GetacSwrdcIpcCore
    {
    }

    class GetacSwrdcIpcApi
    {
        public NetworkStream ApiTcpServer (int port_var)
        {
            GetacSwrdcUtil.DebugIt("ApiTcpServer", "start");
            NetworkStream stream = TcpServer(port_var);
            GetacSwrdcUtil.DebugIt("ApiTcpServer", "end");
            return stream;
        }

        public NetworkStream TcpServer (int port_var)
        {
            GetacSwrdcUtil.DebugIt("TcpServer", "start");

            TcpListener listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), port_var);
            listener.Start();
            GetacSwrdcUtil.DebugIt("TcpServer", "after listener.Start()");

            TcpClient client = listener.AcceptTcpClient();
            GetacSwrdcUtil.DebugIt("TcpServer", "after AcceptTcpClient");

            NetworkStream stream = client.GetStream();
            GetacSwrdcUtil.DebugIt("TcpServer", "after GetStream");

            GetacSwrdcUtil.DebugIt("TcpServer", "end");
            return stream;
        }

        public NetworkStream ApiTcpClient (string ip_addr_var, int port_var)
        {
            GetacSwrdcUtil.DebugIt("ApiTcpClient", "start");
            NetworkStream stream = TcpClient(ip_addr_var, port_var);
            GetacSwrdcUtil.DebugIt("ApiTcpClient", "end");
            return stream;
        }

        public NetworkStream TcpClient (string ip_addr_var, int port_var)
        {
            GetacSwrdcUtil.DebugIt("TcpClient", "start");
            TcpClient client = new TcpClient(ip_addr_var, port_var);
            NetworkStream stream = client.GetStream();
            GetacSwrdcUtil.DebugIt("TcpClient", "end");
            return stream;
        }

        public void ApiTcpTransmitData (NetworkStream stream_var, string data_var)
        {
            GetacSwrdcUtil.DebugIt("ApiTcpTransmitData", "start");
            GetacSwrdcUtil.DebugIt("ApiTcpTransmitData", data_var);
            TcpTransmitData(stream_var, data_var);
            GetacSwrdcUtil.DebugIt("ApiTcpTransmitData", "end");
        }

        public void TcpTransmitData (NetworkStream stream_var, string data_var)
        {
            GetacSwrdcUtil.DebugIt("TcpTransmitData", "start");
            GetacSwrdcUtil.DebugIt("TcpTransmitData", data_var);
            BinaryWriter writer = new BinaryWriter(stream_var);
            writer.Write(data_var);
            writer.Flush();
            GetacSwrdcUtil.DebugIt("TcpTransmitData", "end");
        }

        public void ApiTcpReceiveData (NetworkStream stream_var)
        {
            GetacSwrdcUtil.DebugIt("ApiTcpReceiveData", "start");
            TCpReceiveData(stream_var);
            GetacSwrdcUtil.DebugIt("ApiTcpReceiveData", "end");

        }

        public void TCpReceiveData (NetworkStream stream_var)
        {
            GetacSwrdcUtil.DebugIt("TCpReceiveData", "start");
            BinaryReader reader = new BinaryReader(stream_var);

            try
            {
                string data = reader.ReadString();
                GetacSwrdcUtil.DebugIt("TCpReceiveData", data);
            }
            catch (Exception ex)
            {
                GetacSwrdcUtil.DebugIt("TCpReceiveData", "exception");
            }

            GetacSwrdcUtil.DebugIt("TCpReceiveData", "end");
        }
    }

    class GetacSwrdcUtil
    {
        public static void DebugIt (string var1, string var2)
        {
            DebugIt_(var1, var2);
        }

        static void DebugIt_(string var1, string var2)
        {
            Debug.WriteLine(var2, var1);
        }

        public static void AbendIt (string var1, string var2)
        {

        }
    }
}
