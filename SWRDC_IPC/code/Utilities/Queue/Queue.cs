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

        int QueueLength ()
        {
            return this.QueueLength_;
        }
        void EnqueueEntry (QueueEntryClass entry)
        {

        }

        QueueEntryClass DequeueEntry ()
        {
            return null;
        }
    }
    class QueueEntryClass
    {

    }
}

/*
pthread_mutex_t theMutex;

void enqueueEntry(QueueEntryClass* entry);
QueueEntryClass* dequeueEntry(void);
int queueSize(void) { return this->theQueueSize; }

void abendQueue(char const *msg_val);
void flushQueue(void);

void debug(int on_off_val, char const *str0_val, char const *str1_val) { if (on_off_val) this->logit(str0_val, str1_val); };
void logit(char const *str0_val, char const *str1_val);
void abend(char const *str0_val, char const *str1_val);

public:
    QueueClass(int do_suspend_val, int max_size_val);
~QueueClass(void);
    char const * objectName(void) {return "QueueClass";}
    
    void enqueueData(void* data_val);
void* dequeueData(void);
*/
