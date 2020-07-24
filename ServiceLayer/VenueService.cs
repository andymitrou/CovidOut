using CovidOut.Repositories;
using CovidOut.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace CovidOut.ServiceLayer {
    public class VenueService {

        private readonly IGenericRepository<Venue> _venueRepository;
        private readonly ILogger<VenueService> _logger;
        public VenueService(IGenericRepository<Venue> venueRepository, ILogger<VenueService> logger){
            this._venueRepository = venueRepository;
            this._logger = logger;
        }   

        public IEnumerable<Venue> SearchVenue(string name){
            if (String.IsNullOrWhiteSpace(name)){
                throw new ArgumentNullException("Cannot be empty");
            }
            try
            {   
                var result = _venueRepository.Query(x=>x.Name.ToLowerInvariant() == name.ToLowerInvariant());
                return result;
            }
            catch (System.Exception e)
            {
                this._logger.LogError(e.StackTrace);
                throw;
            }
        }
    }
}