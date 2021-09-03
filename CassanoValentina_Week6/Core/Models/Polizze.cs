using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Client;

namespace TravelAgency
{
    public class Polizze
    {
        private static ClientiContext _polizzeCtx = new ClientiContext();

        [Key]
        public int IdPolizze { get; set; }

        public int NPolizza { get; set; }
        public DateTime DataScadenza { get; set; }
        public int RataMensile { get; set; }
        public TipoPolizzaEnum TipoPolizza { get; set; }



        public enum TipoPolizzaEnum
        {
            RCAuto,
            Furto,
            Vita
        }


        public static void FetchPolizze()
        {
            var polizze = _polizzeCtx.Polizze.ToList();
            Console.WriteLine($"Il numero di polizze è: {polizze.Count}");

            foreach (var p in polizze)
            {
                Console.WriteLine(p.TipoPolizza);

            }
        }
    }
}