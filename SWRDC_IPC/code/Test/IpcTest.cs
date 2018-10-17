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
        static void Main(string[] args)
        {
            Getac.Csc.Util.Ipc.IpcTestClass.TestIpc();
            Thread.Sleep(1000);
       }
    }
}
