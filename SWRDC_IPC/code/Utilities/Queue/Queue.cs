using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getac.Csc.Utilities
{
    class QueueClass
    {
        private int QueueLength_;
        private QueueEntryClass theQueueHead;
        private QueueEntryClass theQueueTail;
        private int MaxQueueSize_;

        public void enqueueData (object data_val)
        {

        }

        public void dequeueData ()
        {

        }

        public int QueueLength()
        {
            return this.QueueLength_;
        }

        private void EnqueueEntry(QueueEntryClass entry)
        {

        }

        private QueueEntryClass DequeueEntry()
        {
            return null;
        }

        private void AbendQueue (string msg_val)
        {
        }

        private void FlushQueue ()
        {

        }
    }
    class QueueEntryClass
    {

    }
}

/*


public:
    QueueClass(int do_suspend_val, int max_size_val);
~QueueClass(void);
    char const * objectName(void) {return "QueueClass";}
    
    void enqueueData(void* data_val);
void* dequeueData(void);
*/
