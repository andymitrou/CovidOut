using CovidOut.Models;
using CovidOut.Repositories;

namespace CovidOut.ServiceLayer {
    public interface IVenueService :IGenericRepository<Venue>
    {
        IEnumerable<Venue> SearchVenue(string name);
    }
}