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
                if (person.Age >= 67) return 1000;
                if (person.Age >= 60 && person.Age <= 67) return 30000; //early pension
                return 0;
            });
            eventChances.Add(ChaosType.NewJob, () =>
            {
                if (person.Age >= 12 && person.Age <= 35) return 2000;
                if (person.Age >= 36 && person.Age <= 70) return 6000;
                return 0;
            });
            eventChances.Add(ChaosType.QuitJob, () =>
            {
                if (person.Age >= 12 && person.Age <= 35) return 2000;
                if (person.Age >= 36 && person.Age <= 70) return 6000;
                return 0;
            });
            eventChances.Add(ChaosType.CreateAccount, () =>
            {
                if (person.Age >= 12 && person.Age <= 70) return 200;
                return 0;
            });
            eventChances.Add(ChaosType.Death, () =>
            {
                if (person.Age >= 12 && person.Age <= 70) return 30000; //ca 80 år
                if (person.Age >= 70) return 7500;
                return 0;
            });
            eventChances.Add(ChaosType.WentShopping, () =>
            {
                return 4;
            });

            foreach (var evnt in eventChances)
            {
                if (rnd.Next(evnt.Value()) == 1) events.Add(new Event { EventType = evnt.Key });
            }

            return events;
        }


    }

}
