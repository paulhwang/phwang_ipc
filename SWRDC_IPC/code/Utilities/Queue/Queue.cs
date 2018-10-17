using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Getac.Csc.Utilities
{
    class QueueClass
    {
        private const int QUEUE_CLASS_DEFAULT_MAX_QUEUE_SIZE = 1000;
        private int QueueLength;
        private QueueEntryClass QueueHead;
        private QueueEntryClass QueueTail;
        private int MaxQueueLength;
        private object Lock;

        public QueueClass(bool do_suspend_val, int max_length_val)
        {
            this.MaxQueueLength = max_length_val;
            this.Lock = new object();


            if (do_suspend_val = true) {
                //this.SuspendObject = new SuspendClass();
            }
            else {
                //this.SuspendObject = nuill;
            }

            if (this.MaxQueueLength == 0) {
                this.MaxQueueLength = QUEUE_CLASS_DEFAULT_MAX_QUEUE_SIZE;
            }

            //this.TheMutex = new Mutex(true, "queue by phwang");
            //if (pthread_mutex_init(&this->theMutex, NULL) != 0) {
                //this->abend("QueueClass", "pthread_mutex_init fail");
            //}
    }



    public void enqueueData (object data_val)
        {
            //this->debug(false, "enqueueData", (char*)data_val);

            /* queue is too big */
            if ((this.MaxQueueLength != 0) && (this.QueueLength > this.MaxQueueLength))
            {
                //phwangFree(data_val, "QueueClass::enqueueData");
                //this->abend("enqueueData", "queue full");
                return;
            }

            QueueEntryClass entry = new QueueEntryClass();
            if (entry == null)
            {
                //this->abend("enqueueData", "fail to create new QueueEntryClass");
                return;
            }
            entry.data = data_val;

            this.AbendQueue("enqueueData begin");
            lock (this.Lock)
            {
                this.EnqueueEntry(entry);
            }

            this.AbendQueue("enqueueData end");

            //if (this->theSuspendObject)
            {
                //this->theSuspendObject->signal();
            }

        }

        public object dequeueData ()
        {
            QueueEntryClass entry;

            while (true)
            {
                if (this.QueueHead == null)
                {
                    //if (!this->theSuspendObject)
                    {
                        //return 0;
                    }
                    //this->theSuspendObject->wait();
                }
                else
                {
                    this.AbendQueue("dequeueData begin");
                    lock (this.Lock)
                    {
                        entry = this.DequeueEntry();
                    }
                   this.AbendQueue("dequeueData end");

                    if (entry != null)
                    {
                        object data = entry.data;
                        entry = null;

                        //this->debug(false, "dequeueData", (char*)data);
                        return data;
                    }
                }
            }

        }

        private void EnqueueEntry(QueueEntryClass entry)
        {
            if (this.QueueHead == null)
            {
                entry.next = null;
                entry.prev = null;
                this.QueueHead = entry;
                this.QueueTail = entry;
                this.QueueLength = 1;
            }
            else
            {
                entry.next = null;
                entry.prev = this.QueueTail;
                this.QueueTail.next = entry;
                this.QueueTail = entry;
                this.QueueLength++;
            }
        }

        private QueueEntryClass dequeueEntry ()
        {
            QueueEntryClass entry;

            if (this.QueueLength == 0)
            {
                //this->abend("dequeueEntry", "theQueueSize == 0");
                return null;
            }

            if (this.QueueLength == 1)
            {
                entry = this.QueueHead;
                this.QueueHead = this.QueueTail = null;
                this.QueueLength = 0;
                return entry;
            }

            entry = this.QueueHead;
            this.QueueHead = this.QueueHead.next;
            this.QueueHead.prev = null;
            this.QueueLength--;

            return entry;
        }

        public int GetQueueLength()
        {
            return this.QueueLength;
        }

        private QueueEntryClass DequeueEntry()
        {
            return null;
        }

        private void AbendQueue (string msg_val)
        {
            QueueEntryClass entry;
            int length;

            if (this == null)
            {
               // this->abend("abendQueue", "null this");
                return;
            }

            if (this.QueueLength == 0)
            {
                if ((this.QueueHead != null) || (this.QueueTail != null))
                {
                    //this->abend("abendQueue", "theQueueSize == 0");
                    return;
                }
            }
            else
            {
                if (this.QueueHead != null)
                {
                    //this->abend("abendQueue", "null theQueueHead");
                    return;
                }
            }

            lock (this.Lock)
            {
                length = 0;
                entry = this.QueueHead;
                while (entry != null)
                {
                    length++;
                    entry = entry.next;
                }

                if (length != this.QueueLength)
                {
                    //printf("%s length=%d %d\n", msg_val, length, this->theQueueSize);
                    //this->abend("abendQueue", "from head: bad length");
                }

                length = 0;
                entry = this.QueueTail;
                while (entry != null)
                {
                    length++;
                    entry = entry.prev;
                }

                if (length != this.QueueLength)
                {
                    //printf("%s length=%d %d\n", msg_val, length, this->theQueueSize);
                    //this->abend("abendQueue", "from tail: bad length");
                }
            }
        }

        private void FlushQueue ()
        {
            QueueEntryClass entry, entry_next;

            //pthread_mutex_lock(&this->theMutex);
            entry = this.QueueHead;
            while (entry != null)
            {
                entry_next = entry.next;
                //phwangFree(entry->data, "QueueClass::flushQueue");
                //delete entry;
                this.QueueLength--;
                entry = entry_next;
            }
            this.QueueHead = this.QueueTail = null;

            if (this.QueueLength != 0)
            {
                //this->abend("flushQueue", "theQueueSize");
            }

            //pthread_mutex_unlock(&this->theMutex);
        }
    }

    class QueueEntryClass
    {
        public QueueEntryClass next;
        public QueueEntryClass prev;
        public object data;

        void deleteQueueEntry ()
        {

        }
    }
}
