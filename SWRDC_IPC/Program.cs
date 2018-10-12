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

namespace SWRDC_IPC
{
    class Program
    {
        static void Main(string[] args)
        {
            GetacSwrdcUtil.DebugIt("Main", "start");

            Thread server_thread = new Thread(TestServer);
            server_thread.Start(5);

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

            NetworkStream stream = ipc_api.ApiListener(port);
            if (stream == null)
            {
                return;
            }

            ipc_api.ApiReceiveString(stream);
        }

        static void TestClient (object var)
        {
            string ip_addr = "127.0.0.1";
            int port = 9000;
            GetacSwrdcIpcApi ipc_api = new GetacSwrdcIpcApi {};

            NetworkStream stream = ipc_api.ApiClient(ip_addr, port);
            if (stream == null)
            {
                GetacSwrdcUtil.DebugIt("TestClient", "***** null stream");
                return;
            }

            Thread.Sleep(3000);
            ipc_api.ApiTransmitString(stream, "hellp from phwang");
        }
    }

    class GetacSwrdcIpcApi
    {
        public NetworkStream ApiListener (int port_var)
        {
            GetacSwrdcUtil.DebugIt("ApiListener", "start");

            TcpListener listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), port_var);
            listener.Start();
            GetacSwrdcUtil.DebugIt("ApiListener", "after listener.Start()");

            Socket socket = listener.AcceptSocket();
            GetacSwrdcUtil.DebugIt("ApiListener", "after AcceptSocket()");

            NetworkStream stream = new NetworkStream(socket);
            //NetworkStream stream = socket.GetStream();
            GetacSwrdcUtil.DebugIt("ApiListener", "after NetworkStream");

            /*
            try
            {
                byte[] bytesFrom = new byte[10025];
                stream.Read(bytesFrom, 0, (int)socket.ReceiveBufferSize);
                string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                GetacSwrdcUtil.DebugIt("ApiListener", dataFromClient);

                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                Console.WriteLine(" >> Data from client - " + dataFromClient);
            }
            catch (Exception ex)
            {
                GetacSwrdcUtil.DebugIt("ApiListener", "exception");
            }
            */

            GetacSwrdcUtil.DebugIt("ApiListener", "end");
            return stream;
        }

        public NetworkStream ApiClient (string ip_addr_var, int port_var)
        {
            GetacSwrdcUtil.DebugIt("ApiClient", "start");

            //TcpClient client = new TcpClient();
            //IPEndPoint server_end_point = new IPEndPoint(IPAddress.Parse(ip_addr_var), port_var);
            //client.Connect(server_end_point);


            System.Net.Sockets.TcpClient client_socket = new System.Net.Sockets.TcpClient();
            client_socket.Connect(ip_addr_var, port_var);
            NetworkStream stream = client_socket.GetStream();

            GetacSwrdcUtil.DebugIt("ApiClient", "end");
            return stream;
        }

        public void ApiTransmitData (NetworkStream stream_var, string data_var)
        {
            GetacSwrdcUtil.DebugIt("ApiTransmitData", data_var);
            StreamReader reader = new StreamReader(stream_var);

            byte[] data = System.Text.Encoding.ASCII.GetBytes(data_var + "$");
            //byte[] data = "hello from phwang";
            stream_var.Write(data, 0, data.Length);
            stream_var.Flush();
        }

        public void ApiTransmitString(NetworkStream stream_var, string data_var)
        {
            GetacSwrdcUtil.DebugIt("ApiTransmitString", data_var);
            StreamReader reader = new StreamReader(stream_var);

            byte[] data = System.Text.Encoding.ASCII.GetBytes(data_var + "$");
            //byte[] data = "hello from phwang";
            stream_var.Write(data, 0, data.Length);
            stream_var.Flush();
        }

        public void ApiReceiveData (NetworkStream stream_var)
        {
            GetacSwrdcUtil.DebugIt("ApiReceiveData", "start");
            StreamReader reader = new StreamReader(stream_var);

            try
            {
                string data = reader.ReadLine();
                GetacSwrdcUtil.DebugIt("ApiListener", data);
            }
            catch (Exception ex)
            {
                GetacSwrdcUtil.DebugIt("ApiListener", "exception");
            }

            GetacSwrdcUtil.DebugIt("ApiReceiveData", "end");
        }

        public void ApiReceiveString(NetworkStream stream_var)
        {
            GetacSwrdcUtil.DebugIt("ApiReceiveString", "start");
            StreamReader reader = new StreamReader(stream_var);

            try
            {
                string data = reader.ReadLine();
                GetacSwrdcUtil.DebugIt("ApiListener", data);
            }
            catch (Exception ex)
            {
                GetacSwrdcUtil.DebugIt("ApiListener", "exception");
            }
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
