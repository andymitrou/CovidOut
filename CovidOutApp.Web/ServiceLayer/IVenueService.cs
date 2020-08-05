using System;
using System.Collections.Generic;
using CovidOutApp.Web.Models;
using CovidOutApp.Web.Repositories;

namespace CovidOutApp.Web.ServiceLayer {
    public interface IVenueService
    {   
        IEnumerable<Venue> SearchVenue(string name);
        IEnumerable<Venue> GetAllVenues();
        IEnumerable<Venue> GetVenuesOwnedByUser(string userId);
        Venue GetVenueById(Guid id);
        void CreateVenue(Venue venue);
        void DeleteVenue (Guid id);
        void EditVenueDetails(Guid id);
        bool CheckInVisitor(Visit venueVisit); 
        bool CheckOutVisitor(Visit venueVisit);
        Visit FindVisitByVenueIdAndUser(Guid venueId, ApplicationUser user);
        bool UserHasCheckedOut(Venue venue, ApplicationUser user);
    }
}