using Pandora.Access.Access;
using Pandora.Common.Interface;
using PandoraSimEngine.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Pandora.Common;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace PandoraSimEngine
{
    internal class SimEngine
    {
        public bool IsRunning { get; set; } = false;
        public bool IsPaused { get; set; } = false;


        private DateTime _simStart;
        private Chaos _chaos;
        private Shopping _shopping;
        private List<PersonData> _population;
        private IPandoraAccess _service;
        const string SimulationStateFile = @"SimulationState.json";

        public SimEngine(List<PersonData> populationData, IPandoraAccess service)
        {
            IsRunning = true;
            _chaos = new Chaos();
            _shopping = new Shopping();
            _population = populationData;
            _service = service;
        }

        public void Start()
        {
            var simulation = new Simulation();

            var currentDate = _service.GetCurrentDate();
            var previousDate = currentDate.AddDays(-1);

            if (File.Exists(SimulationStateFile) && new FileInfo(SimulationStateFile).Length > 0)
            {
                var fileData = File.ReadAllText(SimulationStateFile);
                simulation = JsonConvert.DeserializeObject<Simulation>(fileData);
                previousDate = simulation.LastSimulation;
            }
            else
            {
                simulation.PersonList = _population;
            }

            _simStart = DateTime.Now;

            Log($"*** STARTING SIMULATION ***");

            while (IsRunning)
            {
                while (IsPaused && IsRunning)
                {
                    Thread.Sleep(10);
                }

                var sw = Stopwatch.StartNew();
                var numberOfDaysSinceLastRun = (int)currentDate.Subtract(previousDate).TotalDays;

                for (int i = 0; i < numberOfDaysSinceLastRun; i++)
                {
                    Log($"Processing {previousDate.AddDays(i):yyyy-MM-dd}.");

                    foreach (var person in simulation.PersonList)
                    {
                        if (currentDate.Day == 1)
                        {
                            var newBankDebit = _service.GetSalary(person);
                            if (newBankDebit > 0) person.Card = newBankDebit;
                        }

                        var events = _chaos.GetEvents(person);
                        foreach (var @event in events)
                        {
                            ProcessEvent(person, @event);
                        }
                    }
                }

                previousDate = currentDate;
                simulation.LastSimulation = currentDate;
                Thread.Sleep(Math.Max(0, 120000 - (int)sw.ElapsedMilliseconds)); //1 day per 2 minutes
                currentDate = _service.GetCurrentDate();
            }

            var json = JsonConvert.SerializeObject(simulation);
            File.WriteAllText(SimulationStateFile, json, Encoding.GetEncoding("ISO-8859-1"));

            Log($"*** SIMULATION ENDED ***");
        }

        private void ProcessEvent(PersonData person, Event @event)
        {
            switch (@event.EventType)
            {
                case ChaosType.CreateAccount:
                    if (!person.HasAccount)
                    {
                        object value = _service.CreateAccount(person);
                        person.HasAccount = true;
                        Log($"Person {person.OrignalData.Identifikator} created account.");
                    }
                    break;
                case ChaosType.NewJob:
                    if (!person.HasJob)
                    {
                        _service.NewJob(person);
                        person.HasJob = true;
                        Log($"Person {person.OrignalData.Identifikator} started in a new job.");
                    }
                    break;

                case ChaosType.QuitJob:
                    if (person.HasJob)
                    {
                        _service.QuitJob(person);
                        person.HasJob = false;
                        Log($"Person {person.OrignalData.Identifikator} just quit their job.");
                    }
                    break;

                case ChaosType.WentShopping:
                    var product = _shopping.GetProduct();

                    if (person.Cash >= product.price)
                    {
                        person.Cash -= product.price;
                        Log($"Person {person.OrignalData.Identifikator} bought with CASH: {product.product} ({product.description}) for {product.price}. {person.Cash} cash left.");
                    }
                    else
                    {
                        person.Card -= product.price;
                        _service.BuyProduct(person, product.product, product.description, product.price);
                        Log($"Person {person.OrignalData.Identifikator} bought: {product.product} ({product.description}) for {product.price}. {person.Card} left on card.");
                    }
                    break;

                case ChaosType.WithdrawMoney:
                    float amount1 = new Random().Next(10000) + 1;
                    bool ok = _service.WithdrawMoney(person, amount1);
                    if (ok)
                    {
                        person.Cash += amount1;
                        Log($"Person {person.OrignalData.Identifikator} withdrew {amount1}.");
                    }
                    break;

                case ChaosType.DepositMoney:
                    float amount2 = new Random().Next(10000) + 1;
                    if (person.Cash >= amount2)
                    {
                        person.Cash -= amount2;
                        _service.DepositMoney(person, amount2);
                        Log($"Person {person.OrignalData.Identifikator} withdrew {amount2}.");
                    }
                    break;
            }
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Log(string logText)
        {
            Console.WriteLine(logText);
            File.AppendAllText($"Simulation_{_simStart:yyyy-MM-dd_HH-mm}.log", logText, Encoding.GetEncoding("ISO-8859-1"));
        }
    }
}
