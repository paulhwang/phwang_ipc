using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetacSwrdc.IpcBase
{
    class IpcBaseClass
    { 
        private GetacSwrdc.IpcApi.IpcApiClass IpcApi_;
        private GetacSwrdc.IpcPath.IpcPathClass IpcPath_;
        private GetacSwrdc.IpcTcp.IpcTcpClass IpcTcp_;

        public IpcBaseClass ()
        {
            this.IpcApi_ = new GetacSwrdc.IpcApi.IpcApiClass(this);
            this.IpcTcp_ = new IpcTcp.IpcTcpClass();
            this.IpcPath_ = new IpcPath.IpcPathClass();
        }

        public GetacSwrdc.IpcApi.IpcApiClass IpcApi()
        {
            return IpcApi_;
        }

        public GetacSwrdc.IpcPath.IpcPathClass IpcPath()
        {
            return IpcPath_;
        }
    }
}
