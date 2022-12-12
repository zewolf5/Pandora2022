using Newtonsoft.Json;
using Pandora.Access.Access;
using Pandora.Access.Access.Http;
using PandoraSimEngine;
using PandoraSimEngine.Entities;
using Pandora.Common;
using Pandora.Common.Dto;

internal class Program
{
    private static void Main(string[] args)
    {
        //TestEvents();

        var personDataPath = @"C:\temp\persons.json";
        var populationData = GetPopulationData();
        var service = new PandoraService(new HttpRestClient(new JsonNewtonSerializer(new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        })));

        if (!File.Exists(personDataPath))
        {
            try
            {
                foreach (var person in populationData)
                {
                    string firstname = person.OrignalData.Visningnavn.Split(" ", StringSplitOptions.None)[0];
                    string lastName = person.OrignalData.Visningnavn.Split(" ", StringSplitOptions.None)[1];

                    var personPassport = service.RegisterIndividual(new Registration
                    {
                        community = "Chaffee",
                        dateOfBirth = person.OrignalData.Foedselsdato,
                        first_name = firstname,
                        last_name = lastName,
                        gender = person.OrignalData.Kjoenn == "kvinne" ? "FEMALE" : "MALE",
                        material_status = person.OrignalData.Sivilstand == "ugift" ? "SINGLE" : "MARRIED",
                        pandoran_ssn = person.OrignalData.Identifikator,
                        official_address = person.OrignalData.Bostedsadresse,
                        registration_office_identification = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJQYW5kb3JhbkhvbWVPZmZpY2UiLCJzdWIiOiJQYW5kb3JhbkhvbWVPZmZpY2UiLCJpYXQiOjE2NjY2NDg4MDAsImV4cCI6MTcyOTgwNzIwMCwidHlwIjoiSldUIiwiZG9jdW1lbnRfdHlwZSI6IlBBTkRPUkFOX0dPVkVSTUVOVF9PRkZJQ0UiLCJvZmZpY2VfdHlwZSI6IkdPVl9SRUdfT0ZGSUNFIiwib2ZmaWNlX25hbWUiOiJDaGFmZmVlIn0.zYTbw_NUbxyz8QZJdxmo8Bvrc94ElzYulTlfkkiM4UU\r\n\r\n"
                    });

                    person.PassportInfo = personPassport;
                    Thread.Sleep(100);
                }

            }
            catch (Exception ex)
            {
                int t = 100;
            }

            var str = JsonConvert.SerializeObject(populationData);
            File.WriteAllText(personDataPath, str);
        }
        else
        {
            populationData = JsonConvert.DeserializeObject<List<PersonData>>(File.ReadAllText(personDataPath));
        }


        var sim = new SimEngine(populationData
            .Where(t => !string.IsNullOrEmpty(t.PassportInfo.passport)).ToList(), service);

        sim.Start();
    }

    private static List<PersonData> GetPopulationData()
    {
        var jsonData = File.ReadAllText(@"Data\nøkkelinfo_200.json");
        var docList= JsonConvert.DeserializeObject<Fildata>(jsonData);

        return docList!.dokumentListe
            .Select(t => new PersonData
            {
                OrignalData = t
            }).ToList();
    }


    private static void TestEvents()
    {
        var ev = new Chaos();
        for (int i = 0; i < 10000; i++)
        {
            var events = ev.GetEvents(new PersonData { Age = 50 });
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