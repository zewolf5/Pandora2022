using Newtonsoft.Json;
using PandoraSimEngine;
using PandoraSimEngine.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        var personDataPath = @"C:\temp\persons.json";
        TestEvents();
        var populationData = GetPopulationData();
        var service = new TheService();

        var persons = new List<SimPerson>();
        if (!File.Exists(personDataPath))
        {
            foreach (var person in populationData.Persons)
            {
                var simPerson = service.RegisterPerson(person);
                persons.Add(simPerson);
            }

            var str = JsonConvert.SerializeObject(persons);
            File.WriteAllText(personDataPath, str);
        }
        else
        {
            persons = JsonConvert.DeserializeObject<List<SimPerson>>(personDataPath);
        }

        //Persistering

        var sim = new SimEngine(populationData, service);

        sim.Start();
    }

    private static Population GetPopulationData()
    {
        return null;
    }


    private static void TestEvents()
    {
        var ev = new Chaos();
        for (int i = 0; i < 10000; i++)
        {
            var events = ev.GetEvents(new Person { Age = 50 });
            if (events.Any())
            {
                foreach (var evnt in events)
                {
                    Console.WriteLine($"{i} - {evnt.EventType}");
                }
            }

        }
    }
}