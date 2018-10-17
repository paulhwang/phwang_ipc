using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getac.Csc.Util.Ipc
{
    class IpcBaseClass
    { 
        private IpcApiClass IpcApi_;
        private IpcPathClass IpcPath_;
        private IpcTcpClass IpcTcp_;

        public IpcBaseClass ()
        {
            this.IpcApi_ = new IpcApiClass(this);
            this.IpcTcp_ = new IpcTcpClass(this);
            this.IpcPath_ = new IpcPathClass(this);
        }

        public IpcApiClass IpcApi()
        {
            return IpcApi_;
        }

        public IpcPathClass IpcPath()
        {
            return IpcPath_;
        }

        public IpcTcpClass IpcTcp()
        {
            return IpcTcp_;
        }
    }
}
