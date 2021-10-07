using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Outings
{
    public class OutingsContent
    {
        List<string> allOutingsEvents = new List<string>();
        List<double> allOutingsCost = new List<double>();

        public OutingsContent(string eventType, int numberOfAttendes, DateTime dateOfOuting, double totalCostPerPerson, double totalCostOfEvent)
        {
            EventType = eventType;
            Attendes = numberOfAttendes;
            OutingDate = dateOfOuting;
            PersonCost = totalCostPerPerson;
            EventCost = totalCostOfEvent;
        }

        public string EventType { get; set; }

        public int Attendes { get; set; }

        public DateTime OutingDate { get; set; }

        public double PersonCost { get; set; }

        public double EventCost { get; set; }
        
    }
}
