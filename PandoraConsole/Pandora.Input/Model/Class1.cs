using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Input.Model
{
    internal class Class1
    {

        public class Rootobject
        {
            public Dokumentliste[] dokumentListe { get; set; }
            public Fasetter fasetter { get; set; }
        }

        public class Fasetter
        {
        }

        public class Dokumentliste
        {
            public string sisteHendelse { get; set; }
            public string bostedsadresse { get; set; }
            public string visningnavn { get; set; }
            public string personstatus { get; set; }
            public string kjoenn { get; set; }
            public string identifikator { get; set; }
            public string foedselsdato { get; set; }
            public string sivilstand { get; set; }
            public string adresseBeskyttelse { get; set; }
        }

    }
}
