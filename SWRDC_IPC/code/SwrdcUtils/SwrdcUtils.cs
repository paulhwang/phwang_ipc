using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getac.Swrdc.Utils
{
    class DebugClass
    {
        public static void DebugIt(string var1, string var2)
        {
            DebugIt_(var1, var2);
        }

        static void DebugIt_(string var1, string var2)
        {
            System.Diagnostics.Debug.WriteLine(var2, var1);
        }

        public static void AbendIt(string var1, string var2)
        {
            System.Diagnostics.Debug.WriteLine("***", "ABEND");
            System.Diagnostics.Debug.WriteLine(var2, var1);
            System.Diagnostics.Debug.WriteLine("***", "ABEND");
        }
    }
}
