using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetacSwrdc.IpcBase
{
    class IpcBaseClass
    { 
        public GetacSwrdc.IpcApi.IpcApiClass IpcApi;
        public GetacSwrdc.IpcPath.IpcPathClass IpcPath;
        public GetacSwrdc.IpcTcp.IpcTcpClass IpcTcp;

        public IpcBaseClass ()
        {
            this.IpcApi = new GetacSwrdc.IpcApi.IpcApiClass { };

        }
    }
}
