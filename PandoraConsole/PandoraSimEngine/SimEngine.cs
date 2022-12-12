using PandoraSimEngine.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace PandoraSimEngine
{
    internal class SimEngine
    {
        private bool _isRunning = false;
        private Chaos _chaos;
        private Population _population;
        private TheService _service;

        public SimEngine(Population populationData, TheService service)
        {
            _isRunning = true;
            _chaos = new Chaos();
            _population = populationData;
            _service = service;

        }

        public void Start()
        {
            var persons = _population.Persons;
            while (_isRunning)
            {
                var sw = Stopwatch.StartNew();
                foreach (var person in persons)
                {
                    var events = _chaos.GetEvents(person);
                    foreach (var @event in events)
                    {
                        ProcessEvent(person, @event);
                    }
                }



                Thread.Sleep(Math.Max(0, 120000 - (int)sw.ElapsedMilliseconds)); //1 day per 2 minutes
            }
            Console.WriteLine($"Sim ending");
        }

        private void ProcessEvent(Person person, Event @event)
        {
            switch (@event.EventType)
            {
                case ChaosType.Death:
                    if (!person.IsDead)
                    {
                        _service.MarkDead(person);
                        person.IsDead = true;
                        Console.WriteLine($"Person {person.Id} just died.");
                    }
                    break;
                case ChaosType.CreateAccount:
                    if (!person.HasAccount)
                    {
                        _service.CreateAccount(person);
                        person.HasAccount = true;
                        Console.WriteLine($"Person {person.Id} created account.");
                    }
                    break;
                case ChaosType.NewJob:
                    if (!person.HasJob)
                    {
                        _service.NewJob(person);
                        person.HasJob = true;
                        Console.WriteLine($"Person {person.Id} started in a new job.");
                    }
                    break;
                case ChaosType.QuitJob:
                    if (person.HasJob)
                    {
                        _service.QuitJob(person);
                        person.HasJob = false;
                        Console.WriteLine($"Person {person.Id} just quit their job.");
                    }
                    break;
                case ChaosType.Retired:
                    if (!person.IsPensionist)
                    {
                        _service.MarkPensionist(person);
                        person.IsPensionist = true;
                        Console.WriteLine($"Person {person.Id} created account.");
                    }
                    break;
                default:

                    break;
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
