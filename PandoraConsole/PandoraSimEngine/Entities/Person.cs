using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraSimEngine.Entities
{
    internal class Person
    {
        public bool IsDead { get; set; }
        public bool IsPensionist { get; set; }
        public bool HasAccount { get; set; }
        public bool HasJob { get; set; }
        public object Id { get; internal set; }
        public int Age { get; internal set; }
        //Community
        //Cash
    }
}
