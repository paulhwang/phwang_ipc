using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetacSwrdc
{
    class Program
    {
        static void Main(string[] args)
        {
            GetacSwrdcUtilClass.DebugIt("Main", "start");

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

            GetacSwrdcUtilClass.DebugIt("Main", "end");
        }

        private static void TestServer (object var)
        {
            int port = 9000;
            GetacSwrdcIpcApiClass ipc_api = new GetacSwrdcIpcApiClass {};

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
            GetacSwrdcIpcApiClass ipc_api = new GetacSwrdcIpcApiClass {};

            NetworkStream stream = ipc_api.ApiTcpClient(ip_addr, port);
            if (stream == null)
            {
                GetacSwrdcUtilClass.DebugIt("TestClient", "***** null stream");
                return;
            }

            Thread.Sleep(3000);
            ipc_api.ApiTcpTransmitData(stream, "hellp from phwang");
        }
    }

    class GetacSwrdcIpcCoreClass
    {
        public NetworkStream TcpServer(int port_var)
        {
            GetacSwrdcUtilClass.DebugIt("TcpServer", "start");

            TcpListener listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), port_var);
            listener.Start();
            GetacSwrdcUtilClass.DebugIt("TcpServer", "after listener.Start()");

            TcpClient client = listener.AcceptTcpClient();
            GetacSwrdcUtilClass.DebugIt("TcpServer", "after AcceptTcpClient");

            NetworkStream stream = client.GetStream();
            GetacSwrdcUtilClass.DebugIt("TcpServer", "after GetStream");

            GetacSwrdcUtilClass.DebugIt("TcpServer", "end");
            return stream;
        }

        public NetworkStream TcpClient(string ip_addr_var, int port_var)
        {
            GetacSwrdcUtilClass.DebugIt("TcpClient", "start");
            TcpClient client = new TcpClient(ip_addr_var, port_var);
            NetworkStream stream = client.GetStream();
            GetacSwrdcUtilClass.DebugIt("TcpClient", "end");
            return stream;
        }

        public void TcpTransmitData(NetworkStream stream_var, string data_var)
        {
            GetacSwrdcUtilClass.DebugIt("TcpTransmitData", "start");
            GetacSwrdcUtilClass.DebugIt("TcpTransmitData", data_var);
            BinaryWriter writer = new BinaryWriter(stream_var);
            writer.Write(data_var);
            writer.Flush();
            GetacSwrdcUtilClass.DebugIt("TcpTransmitData", "end");
        }

        public void TCpReceiveData(NetworkStream stream_var)
        {
            GetacSwrdcUtilClass.DebugIt("TCpReceiveData", "start");
            BinaryReader reader = new BinaryReader(stream_var);

            try
            {
                string data = reader.ReadString();
                GetacSwrdcUtilClass.DebugIt("TCpReceiveData", data);
            }
            catch (Exception ex)
            {
                GetacSwrdcUtilClass.DebugIt("TCpReceiveData", "exception");
            }

            GetacSwrdcUtilClass.DebugIt("TCpReceiveData", "end");
        }
    }

    class GetacSwrdcIpcApiClass
    {
        private GetacSwrdcIpcCoreClass ipc_core = new GetacSwrdcIpcCoreClass();

        public NetworkStream ApiTcpServer (int port_var)
        {
            GetacSwrdcUtilClass.DebugIt("ApiTcpServer", "start");
            NetworkStream stream = ipc_core.TcpServer(port_var);
            GetacSwrdcUtilClass.DebugIt("ApiTcpServer", "end");
            return stream;
        }

        public NetworkStream ApiTcpClient (string ip_addr_var, int port_var)
        {
            GetacSwrdcUtilClass.DebugIt("ApiTcpClient", "start");
            NetworkStream stream = ipc_core.TcpClient(ip_addr_var, port_var);
            GetacSwrdcUtilClass.DebugIt("ApiTcpClient", "end");
            return stream;
        }

        public void ApiTcpTransmitData (NetworkStream stream_var, string data_var)
        {
            GetacSwrdcUtilClass.DebugIt("ApiTcpTransmitData", "start");
            GetacSwrdcUtilClass.DebugIt("ApiTcpTransmitData", data_var);
            ipc_core.TcpTransmitData(stream_var, data_var);
            GetacSwrdcUtilClass.DebugIt("ApiTcpTransmitData", "end");
        }

        public void ApiTcpReceiveData (NetworkStream stream_var)
        {
            GetacSwrdcUtilClass.DebugIt("ApiTcpReceiveData", "start");
            ipc_core.TCpReceiveData(stream_var);
            GetacSwrdcUtilClass.DebugIt("ApiTcpReceiveData", "end");

        }
    }

    class GetacSwrdcUtilClass
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
