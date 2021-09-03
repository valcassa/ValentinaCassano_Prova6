using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Client
{
    internal class EFClientiRepository : IClientiRepository
    {
        private readonly ClientiContext clientiCtx;
        public EFClientiRepository() { clientiCtx = new ClientiContext(); }


        public bool Add(Clienti newClienti)
        {
            if (newClienti == null)

            try
            {
                var clienti = clientiCtx.Clienti
                    .FirstOrDefault(c => c.IdClienti == newClienti.IdClienti);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        public bool Delete(Clienti item)
        {
            throw new System.NotImplementedException();
        }

        public List<Clienti> Fetch()
        {
            throw new System.NotImplementedException();
        }
         
        public Clienti GetByCodFiscale(string codfiscale)
        {
            if (string.IsNullOrEmpty(codfiscale))
                return null;

            try
            {
                var cliente = clientiCtx.Clienti.Where(c => c.CodFiscale == codfiscale).FirstOrDefault();

                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Clienti GetByCodiceFiscale(string codfiscale)
        {
            throw new NotImplementedException();
        }

        public Clienti GetById(int id)
        {
            if (id <= 0)
                return null;

            return clientiCtx.Clienti.Find(id);
        }

        public bool Update(Clienti updateClienti)
        {
            if (updateClienti == null)
                return false;

            try
            {
                clientiCtx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}