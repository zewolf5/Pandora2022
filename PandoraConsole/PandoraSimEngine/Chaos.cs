using PandoraSimEngine.Entities;
using Pandora.Common;

namespace PandoraSimEngine
{
    internal class Chaos
    {
        public List<Event> GetEvents(PersonData person)
        {
            var rnd = new Random();
            var events = new List<Event>();
            person.Age = person.OrignalData.Foedselsdato;
            var eventChances = new Dictionary<ChaosType, Func<int>>();

            if (!person.HasJob && !person.HasAccount)
            {
                if (person.Age >= 18)
                {
                    eventChances.Add(ChaosType.NewJob, () => 1);
                }
                eventChances.Add(ChaosType.CreateAccount, () => 1);

                eventChances.Add(ChaosType.WentShopping, () =>
                {
                    return 2;
                });
            }
            else
            {
                eventChances.Add(ChaosType.Retired, () =>
                {
                    if (person.Age >= 67) return 1000;
                    if (person.Age >= 60 && person.Age <= 67) return 30000; //early pension
                    return 0;
                });
                eventChances.Add(ChaosType.NewJob, () =>
                {
                    if (person.Age >= 18 && person.Age <= 35) return 2000;
                    if (person.Age >= 36 && person.Age <= 70) return 6000;
                    if (person.Age >= 70) return 60000;
                    return 0;
                });
                eventChances.Add(ChaosType.QuitJob, () =>
                {
                    if (person.Age >= 12 && person.Age <= 35) return 2000;
                    if (person.Age >= 36 && person.Age <= 70) return 6000;
                    if (person.Age >= 70) return 2000;
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
                eventChances.Add(ChaosType.DepositMoney, () =>
                {
                    if (person.Age >= 12 && person.Age <= 60) return 1000;
                    if (person.Age >= 60) return 365;
                    return 0;
                });
                eventChances.Add(ChaosType.WithdrawMoney, () =>
                {
                    if (person.Age >= 12 && person.Age <= 60) return 1000;
                    if (person.Age >= 60) return 365;
                    return 0;
                });
            }

            foreach (var evnt in eventChances)
            {
                if (rnd.Next(evnt.Value()) == 0) events.Add(new Event { EventType = evnt.Key });
            }

            return events;
        }


    }

}
