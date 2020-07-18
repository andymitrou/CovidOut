using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CovidOut.Models;

namespace CovidOut.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public DbSet<Venue> Venues {get;set;}
        public DbSet<Visit> Visiti {get;set;}
    }
}
