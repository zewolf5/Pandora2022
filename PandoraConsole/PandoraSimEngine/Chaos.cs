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
            var birthdate = DateTime.Parse(person.OrignalData.Foedselsdato);
            person.Age = GetAge(birthdate);

            var eventChances = new Dictionary<ChaosType, Func<int>>();

            if (!person.HasJob && !person.HasAccount)
            {
                eventChances.Add(ChaosType.CreateAccount, () => 1);

                if (person.Age >= 18)
                {
                    eventChances.Add(ChaosType.NewJob, () => 1);
                }
             
                eventChances.Add(ChaosType.WentShopping, () =>
                {
                    return 2;
                });
            }
            else
            {
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
                //eventChances.Add(ChaosType.CreateAccount, () =>
                //{
                //    if (person.Age >= 12 && person.Age <= 70) return 200;
                //    return 0;
                //});
                //eventChances.Add(ChaosType.Death, () =>
                //{
                //    if (person.Age >= 12 && person.Age <= 70) return 30000; //ca 80 år
                //    if (person.Age >= 70) return 7500;
                //    return 0;
                //});
                eventChances.Add(ChaosType.WentShopping, () =>
                {
                    if (person.OrignalData.Kjoenn == "kvinne")
                    {
                        return 2;
                    }
                    else
                    {
                        return 4;
                    }
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



        private int GetAge(DateTime birth)
        {
            return DateTime.Now.Year - birth.Year;
            //var now = DateTime.Now;
            //if (date.Year > now.Year) date = birth.AddYears(-100);
            //var age = now.Year - date.Year;
            //if (new DateTime(date.Year, now.Month, now.Day) < new DateTime(date.Year, date.Month, date.Day)) age -= 1;
            //return age;
        }
    }

}
