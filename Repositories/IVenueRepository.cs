using CovidOut.Models;

namespace CovidOut.Repositories {
    public interface IVenueRepository {
         Venue FindVenueByName(string name);
    }
}