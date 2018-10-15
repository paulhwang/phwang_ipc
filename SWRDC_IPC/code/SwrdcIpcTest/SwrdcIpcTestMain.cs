using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace GetacIpcTestProgram
{
    class GetacIpcTestProgramClass
    {
        static void Main(string[] args)
        {
            GetacSwrdc.IpcTest.IpcTestClass.TestIpc();
            Thread.Sleep(1000);
       }
    }
}
