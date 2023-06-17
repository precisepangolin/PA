using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class CallQueue : IComparable<CallQueue>
    {
        public List<Call> calls = new List<Call>();

        public List<Agent> agentsList = new List<Agent>();
        public bool HighPriority { get; set; }

        public CallQueue(bool highPriority)
        {
            HighPriority = highPriority;
        }

        public void AddCallToQueue(Call call)
        {
            calls.Add(call);
        }

        private void RemoveCallFromQueue(Call call)
        {
            calls.Remove(call);
        }

        public void RemoveAssignedCallsFromQueue()
        {
            foreach (Call call in calls)
            {
                if (call.HandlingAgent != null)
                {
                    calls.Remove(call);
                }
            }
        }

        public void AssignAgentToCall(Call call)
        {
            int count = calls.Count;
            Agent assignedAgent = null;
            foreach (Agent agent in agentsList)
            {    
                    if (agent.callsHandled.Count < count)
                    {
                        count = agent.callsHandled.Count;
                        assignedAgent = agent;
                    }
            }
            call.AddAgent(assignedAgent);
            assignedAgent.AddCallToHandle(call);
        }

        public Call GetLongestWaitingCall()
        {
            TimeSpan counter = TimeSpan.Zero;
            DateTime now = DateTime.Now;
            Call longestWaitingCall = null;
            foreach (Call call in calls)
            {
                TimeSpan difference = now - call.EntryTime;
                if (difference > counter)
                {
                    counter = difference;
                    longestWaitingCall = call;
                }
            }
            return longestWaitingCall;
        }

        public bool AgentCanBeAdded(Agent agent)
        {
            if (this.HighPriority == true && agent.SeniorityLevel != Seniority.SeniorityLevel.LevelC)
            {
                return false;
            }
            return true;
        }

        public void AddAgentsToQueue(List<Agent> agents)
        {
            foreach(Agent agent in agents)
            {
                if (this.AgentCanBeAdded(agent))
                {
                    agentsList.Add(agent);
                }
            }
        }

        public int CompareTo(CallQueue? other)
        {
            return this.calls.Count.CompareTo(other.calls.Count);
        }
    }
}
