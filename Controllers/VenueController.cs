using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidOut.Data;
using CovidOut.ViewModels;
using CovidOut.Models;
using Microsoft.AspNetCore.Authorization;
using CovidOut.Repositories;

namespace CovidOut.Controllers
{
    [Authorize(Roles = "Admin")] 
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public VenueController(ApplicationDbContext context)
        {

            _context = context;
        }

        // GET: Venue
        public async Task<IActionResult> Index()
        {
            var venues = new List<VenueViewModel>();
            
            var venuesDb = await _context.Venues.ToListAsync();

            Action<Venue> mapToViewModel= venue => {
                var venueItem = new VenueViewModel {Name = venue.Name, Id = venue.Id};
                venues.Add(venueItem);
            }; 

            venuesDb.ForEach(mapToViewModel);

            return View(venues);
        }

        // GET: Venue/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbVenueItem = await _context.Venues
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dbVenueItem == null)
            {
                return NotFound();
            }

            VenueViewModel venueVM = new VenueViewModel {
                Id = dbVenueItem.Id,
                Name = dbVenueItem.Name,
                Address = dbVenueItem.Address,
                City = dbVenueItem.City,
                Telephone = dbVenueItem.Telephone,
                Email = dbVenueItem.Email,
                Capacity = dbVenueItem.Capacity,
                Open = dbVenueItem.TimeOpens,
                Close = dbVenueItem.TimeCloses
            };

            return View(venueVM);
        }

        // GET: Venue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Address, City, Email, Telephone")] VenueViewModel venue)
        {
            if (ModelState.IsValid)
            {
                var dbVenue = new Venue();
                dbVenue.Id = Guid.NewGuid();
                dbVenue.Name = venue.Name;
                dbVenue.Address = venue.Address;
                dbVenue.City = venue.City;
                dbVenue.Email = venue.Email;
                dbVenue.Telephone = venue.Telephone;
                dbVenue.Capacity = venue.Capacity;
                dbVenue.TimeOpens = venue.Open;
                dbVenue.TimeCloses = venue.Close;

                _context.Add(dbVenue);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        // GET: Venue/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venueDb = await _context.Venues.FindAsync(id);

            if (venueDb == null)
            {
                return NotFound();
            }

            var venueViewModel = new VenueViewModel {
                Id = venueDb.Id,
                Name = venueDb.Name,
                Address = venueDb.Address,
                Telephone = venueDb.Telephone,
                Email = venueDb.Email,
                City = venueDb.City,
                Capacity = venueDb.Capacity,
                Open = venueDb.TimeOpens,
                Close = venueDb.TimeCloses
            };
            return View(venueViewModel);
        }

        // POST: Venue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  VenueViewModel venueViewModel)
        {
            if (id != venueViewModel.Id)            
                return NotFound();
            
            if (ModelState.IsValid)
            {
                try
                {
                    var dbVenue = new Venue {
                        Name = venueViewModel.Name,
                        Id = id,
                        Address = venueViewModel.Address,
                        City = venueViewModel.City,
                        Email = venueViewModel.Email,
                        Telephone = venueViewModel.Telephone,
                        Capacity = venueViewModel.Capacity,
                        TimeOpens = venueViewModel.Open,
                        TimeCloses = venueViewModel.Close
                    };

                    _context.Update(dbVenue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(venueViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venueViewModel);
        }

        // GET: Venue/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venueViewModel = await _context.Venues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venueViewModel == null)
            {
                return NotFound();
            }

            return View(venueViewModel);
        }

        // POST: Venue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var venueViewModel = await _context.Venues.FindAsync(id);
            _context.Venues.Remove(venueViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenueExists(Guid id)
        {
            return _context.Venues.Any(e => e.Id == id);
        }
    }
}
