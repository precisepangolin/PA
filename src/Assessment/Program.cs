using System;

namespace Assessment
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<CallQueue> queues = QueueManager.GenerateCallQueues();
            List<Agent> agents = QueueManager.GenerateAgents();
            List<Manager> managers = QueueManager.GenerateManagers();

            foreach (CallQueue queue in queues) {
                queue.AddAgentsToQueue(agents);
            }

            QueueManager.PopulateCallQueue(queues[0], 3);
            QueueManager.PopulateCallQueue(queues[1], 4);


            foreach (CallQueue queue in queues)
            {
                foreach (Call call in queue.calls)
                {
                    queue.AssignAgentToCall(call);
                }
            }


            Console.WriteLine($"List of managers: ");
            foreach(Manager manager in managers)
            {
                Console.WriteLine($"{manager.Name}");
            }

            Console.WriteLine("List of agents and calls assigned to them:");
            foreach (Agent agent in agents)
            {
                Console.WriteLine($"{agent.Name}:");
                foreach (Call call in agent.callsHandled)
                {
                    Console.WriteLine($"Call {call.Id} entered {call.EntryTime}");
                }
            }

            Console.WriteLine("Call waiting for the longest in high priority queue:");
            Call longCall = queues[0].GetLongestWaitingCall();
            Console.WriteLine($"Call {longCall.Id} entered on {longCall.EntryTime}");

            Console.WriteLine("Call waiting for the longest in regular queue:");
            longCall = queues[1].GetLongestWaitingCall();
            Console.WriteLine($"Call {longCall.Id} entered on {longCall.EntryTime}");

            Console.WriteLine("Queue with most calls waiting:");

            CallQueue longQueue = QueueManager.QueueWithMostCalls(queues);
            if (longQueue.HighPriority)
            {
                Console.WriteLine($"High priority queue with {longQueue.calls.Count} calls");
            }
            else
            {
                Console.WriteLine($"Regular queue with {longQueue.calls.Count} calls");
            }
        }


    }
}
