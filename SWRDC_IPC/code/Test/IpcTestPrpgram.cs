using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Getac.Csc.Utilities.Test
{
    class GetacIpcTestProgramClass
    {
        static void Main (string[] args)
        {
            Getac.Csc.Util.Ipc.IpcTestClass.TestServer("127.0.0.1", 8000);
            Getac.Csc.Util.Ipc.IpcTestClass.TestClient("127.0.0.1", 8000);
            Getac.Csc.Util.Ipc.IpcTestClass.TestIpc("127.0.0.1", 9000);
            Thread.Sleep(1000);
       }
    }
}
