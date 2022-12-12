using PandoraSimEngine.Entities;
using System;
using System.Collections.Generic;
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

        public SimEngine(object populationData)
        {
            _isRunning = true;
            _chaos = new Chaos();
            _population = new Population();
        }

        public void Start()
        {
            var persons = _population.Persons;
            while (_isRunning)
            {
                foreach (var person in persons)
                {
                    var events = _chaos.GetEvents();
                    foreach (var @event in events)
                    {
                        ProcessEvent(person, @event);
                    }
                }



                Thread.Sleep(60000); //1 day per 2 minutes
            }
            Console.WriteLine($"Sim ending");
        }

        private void ProcessEvent(Person person, Event @event)
        {
            switch(@event.EventType)
            {
                case ChaosType.Death:

                    break;
                case ChaosType.CreateAccount:

                    break;
                case ChaosType.NewJob:

                    break;
                case ChaosType.QuitJob:

                    break;
                case ChaosType.StartPension:

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
