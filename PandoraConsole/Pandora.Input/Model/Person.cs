using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pandora.Input.Model.Class1;

namespace Pandora.Input.Model
{
    internal class Dokumentliste
    {
        public string SisteHendelse { get; set; }
        public string Bostedsadresse { get; set; }
        public string Visningnavn { get; set; }
        public string Personstatus { get; set; }
        public string Kjoenn { get; set; }
        public string Identifikator { get; set; }
        public string Foedselsdato { get; set; }
        public string Sivilstand { get; set; }

    }
    internal class Fildata
    {

        public Dokumentliste[] dokumentListe { get; set; }

    }
}
