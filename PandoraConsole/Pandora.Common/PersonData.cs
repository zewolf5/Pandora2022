using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandora.Common.Dto;
using Pandora.Common.Interface;

namespace Pandora.Common
{
    public class PersonData : IPersonData
    {
        public Dokumentliste OrignalData { get; set; }
        public RegistrationResponse PassportInfo { get; set; }
        public bool IsDead { get; set; }
        public bool HasAccount { get; set; }
        public bool HasJob { get; set; }
        public bool IsPensionist { get; set; }
        public int Card { get; set; }
        public int Age { get; set; }
        public int Cash { get; set; }
    }
}
