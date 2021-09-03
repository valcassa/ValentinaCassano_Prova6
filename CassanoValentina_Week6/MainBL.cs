using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Client
{
    public class MainBL
    {
        private static IClientiRepository _clientiRepo;
        private static IPolizzeRepository _polizzeRepo;

        public MainBL(IClientiRepository clientiRepository, IPolizzeRepository polizzeRepository)
        {
            _clientiRepo = clientiRepository;
            _polizzeRepo = polizzeRepository;

        }

        internal void AddClienti(Clienti newClienti)
        {
            if (newClienti == null) throw new ArgumentException();
            _clientiRepo.Add(newClienti);

        }

        internal void UpdatePolizza(Polizze polizzeToUpdate)
        {
            if (polizzeToUpdate == null) throw new ArgumentNullException();
            _polizzeRepo.Update(polizzeToUpdate);
        }

        public static List<Clienti> FetchClienti()
        {
            var cliente = _clientiRepo.Fetch();
            return cliente;

        }

        internal object GetByCodiceFiscale(string codfiscale)
        {
            if (string.IsNullOrEmpty(codfiscale)) throw new ArgumentNullException();

            var cliente = _clientiRepo.GetByCodiceFiscale(codfiscale);
            return cliente;
        }

        internal object FetchPolizze()
        {
            throw new NotImplementedException();
        }
    }
     
}
