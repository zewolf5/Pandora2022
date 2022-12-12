using PandoraSimEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraSimEngine
{
    internal class Chaos
    {
        public List<Event> GetEvents(Person person)
        {
            var rnd = new Random();
            var events = new List<Event>();

            var eventChances = new Dictionary<ChaosType, Func<int>>();

            eventChances.Add(ChaosType.Retired, () =>
            {
                if (person.Age >= 67 && person.Age <= 70) return 1000; // 1/1000 chance (every 3 years)
                return 0;
            });
            eventChances.Add(ChaosType.NewJob, () =>
            {
                if (person.Age >= 12 && person.Age <= 70) return 2000; // 5/10000 chance (every 5 years)
                return 0;
            });

            foreach (var evnt in eventChances)
            {
                if (rnd.Next(evnt.Value()) == 1) events.Add(new Event { EventType = evnt.Key });
            }

            return events;
        }


    }

}
