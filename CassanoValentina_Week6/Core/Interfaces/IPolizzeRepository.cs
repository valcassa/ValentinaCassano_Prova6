using TravelAgency.Core.Interfaces;

namespace TravelAgency.Client
{
    public interface IPolizzeRepository : IRepository<Polizze>
    {

        Polizze GetPolizze(string polizze);


    }
}