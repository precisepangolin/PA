using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Agent : Employee
    {
        public Seniority.SeniorityLevel SeniorityLevel { get; set; }

        public List<Call> callsHandled = new List<Call>();

        public Agent(int id, string name, Seniority.SeniorityLevel seniority)
        {
            Id = id;
            Name = name;
            SeniorityLevel = seniority;
        }

        public void AddCallToHandle(Call call)
        {
            callsHandled.Add(call);
        }
    }
}
