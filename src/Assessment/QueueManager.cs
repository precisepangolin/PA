using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public static class QueueManager
    {
        public static List<Agent> GenerateAgents()
        {
            List<Agent> agents = new List<Agent>();
            Agent agent1 = new Agent(1, "Ron", Seniority.SeniorityLevel.LevelA);
            Agent agent2 = new Agent(2, "Mike", Seniority.SeniorityLevel.LevelB);
            Agent agent3 = new Agent(3, "Bob", Seniority.SeniorityLevel.LevelC);
            agents.Add(agent1);
            agents.Add(agent2);
            agents.Add(agent3);
            return agents;
        }

        public static List<CallQueue> GenerateCallQueues()
        {
            List<CallQueue> queues = new List<CallQueue>();
            CallQueue HighImportanceQueue = new CallQueue(true);
            CallQueue RegularQueue = new CallQueue(false);
            queues.Add(HighImportanceQueue);
            queues.Add(RegularQueue);
            return queues;
        }

        public static List<Manager> GenerateManagers() {
            List<Manager> managers = new List<Manager>();
            Manager manager1 = new Manager(1, "Rick");
            Manager manager2 = new Manager(2, "Josh");
            managers.Add(manager1);
            managers.Add(manager2);
            return managers;
        }

        public static void PopulateCallQueue(CallQueue queue, int numberOfCallsToGenerate)
        {
            for (int i = 0; i < numberOfCallsToGenerate; i++)
            {
                Call newCall = new Call(DateTime.Now);
                queue.AddCallToQueue(newCall);
            }
        } 

        public static CallQueue QueueWithMostCalls(List<CallQueue> queues)
        {

            queues.Sort();
            return queues[1];

        }
    }
}
