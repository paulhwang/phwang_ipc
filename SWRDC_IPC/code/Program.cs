using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace GetacSwrdc
{
    class Program
    {
        static void Main(string[] args)
        {
            GetacSwrdc.IpcTest.IpcTestClass.TestIpc();
            Thread.Sleep(1000);
       }
    }
}
