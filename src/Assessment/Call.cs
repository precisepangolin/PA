using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Call
    {
        private static int m_Counter = 0;
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public bool IsAccepted { get; set; }

        public bool IsCompleted { get; set; }
        public Agent HandlingAgent { get; set; }
        public Call(DateTime entryTime) { 
            EntryTime = entryTime;
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter);
        }

        public void AddAgent(Agent agent)
        {
            HandlingAgent= agent;
        }
    }
}
