using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Client
{
    internal class EFPolizzeRepository : IPolizzeRepository
    {
        private readonly ClientiContext clientiCtx;

        public EFPolizzeRepository()
        {
            clientiCtx = new ClientiContext();
        }


        public bool Add(Polizze item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Polizze item)
        {
            throw new System.NotImplementedException();
        }

        public List<Polizze> Fetch()
        {
            return clientiCtx.Polizze.ToList();
        }

        public Polizze GetById(int id)
        {
            if (id != 0)
                return null;

            var polizze = clientiCtx.Polizze.Where(p => p.IdPolizze == id).FirstOrDefault();
            return polizze;
        }

        public void GetPolizze(string polizze)
        {
            Polizze.FetchPolizze();
                     
        }

        public bool Update(Polizze item)
        {
            throw new System.NotImplementedException();
        }

        Polizze IPolizzeRepository.GetPolizze(string polizze)
        {
            throw new System.NotImplementedException();
        }
    }
}