using Microsoft.AspNetCore.Identity;

namespace CovidOut.Models {
    public class ApplicationUser : IdentityUser {
    public string Title {get;set;}
    [PersonalData]   
    public string FirstName { get; set; }
 
    [PersonalData]  
    public string LastName { get; set; }
    }
}