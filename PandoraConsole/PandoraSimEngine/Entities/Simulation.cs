using Pandora.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraSimEngine.Entities
{
    public class Simulation
    {
        public DateTime LastSimulation{ get; set; }
        public List<PersonData> PersonList { get; set; }
    }
}
