using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Clienti
    {
        [Key]
        public int IdClienti { get; set; }
       
        public string CodFiscale {get; set;}
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Polizze Polizze { get; set; }
        public int PolizzeId { get; set; }
}
}
