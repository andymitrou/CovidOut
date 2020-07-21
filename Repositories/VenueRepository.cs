using CovidOut.Data;
using CovidOut.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CovidOut.Repositories {
    public class VenueRepository : GenericRepository<Venue>
    {
        public VenueRepository(ILogger<GenericRepository<Venue>> logger, ApplicationDbContext db) 
        : base(logger, db){}

       public IEnumerable<Venue> SearchByLocation(double lat, double lon){
           throw new NotImplementedException();
       } 
    }
}