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

namespace PandoraSimEngine
{
    internal class SimEngine
    {
        private bool _isRunning = false;
        private Chaos _chaos;
        private Shopping _shopping;
        private List<PersonData> _population;
        private IPandoraAccess _service;

        public SimEngine(List<PersonData> populationData, IPandoraAccess service)
        {
            _isRunning = true;
            _chaos = new Chaos();
            _shopping = new Shopping();
            _population = populationData;
            _service = service;
        }

        public void Start()
        {
            var persons = _population;
            var currentDate = _service.GetCurrentDate();
            var previousDate = currentDate.AddDays(-1);
            Console.WriteLine($"*** STARTING SIMULATION ***");

            while (_isRunning)
            {
                var sw = Stopwatch.StartNew();

                foreach (var person in persons)
                {
                    if (currentDate.Day == 1)
                    {
                        var newBankDebit = _service.GetSalary(person);
                        if (newBankDebit > 0) person.Card = newBankDebit;
                    }
                    var numberOfDaysSinceLastRun = (int)currentDate.Subtract(previousDate).TotalDays;
                    for (int i = 0; i < numberOfDaysSinceLastRun; i++)
                    {
                        Console.WriteLine($"Processing {previousDate.AddDays(i):yyyy-MM-dd}.");
                        var events = _chaos.GetEvents(person);
                        foreach (var @event in events)
                        {
                            ProcessEvent(person, @event);
                        }
                    }
                    previousDate = currentDate;
                }

                Thread.Sleep(Math.Max(0, 120000 - (int)sw.ElapsedMilliseconds)); //1 day per 2 minutes
                currentDate = _service.GetCurrentDate();
            }
            Console.WriteLine($"Sim ending");
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
                        Console.WriteLine($"Person {person.OrignalData.Identifikator} created account.");
                    }
                    break;
                case ChaosType.NewJob:
                    if (!person.HasJob)
                    {
                        _service.NewJob(person);
                        person.HasJob = true;
                        Console.WriteLine($"Person {person.OrignalData.Identifikator} started in a new job.");
                    }
                    break;

                case ChaosType.QuitJob:
                    if (person.HasJob)
                    {
                        _service.QuitJob(person);
                        person.HasJob = false;
                        Console.WriteLine($"Person {person.OrignalData.Identifikator} just quit their job.");
                    }
                    break;

                case ChaosType.WentShopping:
                    var product = _shopping.GetProduct();

                    if (person.Cash >= product.price)
                    {
                        person.Cash -= product.price;
                        Console.WriteLine($"Person {person.OrignalData.Identifikator} bought with CASH: {product.product} ({product.description}) for {product.price}. {person.Cash} cash left.");
                    }
                    else
                    {
                        person.Card -= product.price;
                        _service.BuyProduct(person, product.product, product.description, product.price);
                        Console.WriteLine($"Person {person.OrignalData.Identifikator} bought: {product.product} ({product.description}) for {product.price}. {person.Card} left on card.");
                    }

                    Console.WriteLine($"Person {person.OrignalData.Identifikator} bought {product.product} ({product.description}) for {product.price}.");
                    break;

                case ChaosType.WithdrawMoney:
                    float amount1 = new Random().Next(10000) + 1;
                    bool ok = _service.WithdrawMoney(person, amount1);
                    if (ok)
                    {
                        person.Cash += amount1;
                        Console.WriteLine($"Person {person.OrignalData.Identifikator} withdrew {amount1}.");
                    }
                    break;

                case ChaosType.DepositMoney:
                    float amount2 = new Random().Next(10000) + 1;
                    if (person.Cash >= amount2)
                    {
                        person.Cash -= amount2;
                        _service.DepositMoney(person, amount2);
                        Console.WriteLine($"Person {person.OrignalData.Identifikator} withdrew {amount2}.");
                    }
                    break;
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
