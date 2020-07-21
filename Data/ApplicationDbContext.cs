using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CovidOut.Models;
using CovidOut.ViewModels;

namespace CovidOut.Data
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public DbSet<Venue> Venues {get;set;}
        public DbSet<Visit> Visits {get;set;}
        public DbSet<Image> Images {get;set;}
    }
}
