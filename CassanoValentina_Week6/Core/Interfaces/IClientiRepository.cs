using System.Collections.Generic;
using TravelAgency.Core.Interfaces;

namespace TravelAgency.Client
{
    public interface IClientiRepository : IRepository<Clienti>
    {
        new bool Add(Clienti newClienti);
        Clienti GetByCodiceFiscale(string codfiscale);
    }
}