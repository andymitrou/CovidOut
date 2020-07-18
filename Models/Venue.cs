using System;

namespace CovidOut.Models {
    public class Venue {
        public Guid Id { get; set; }
        public string Name {get;set;}
        public string Address {get;set;}
        public string City { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; } 
    }
}