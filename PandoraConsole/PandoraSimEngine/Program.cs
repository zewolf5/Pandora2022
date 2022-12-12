using PandoraSimEngine;
using PandoraSimEngine.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        TestEvents();
        var populationData = GetPopulationData();
        var service = new TheService();

        foreach (var person in populationData.Persons)
        {
            service.RegisterPerson(person);
        }

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