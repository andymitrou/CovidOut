using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidOut.Models;
using Microsoft.AspNetCore.Identity;

namespace CovidOut.Controllers
{
 public abstract class BaseController : Controller
    {   
        protected readonly ILogger<BaseController> _logger;
        protected readonly UserManager<IdentityUser>  _userManager;

        public BaseController(ILogger<BaseController> logger, UserManager<IdentityUser> userManager){
            _logger = logger; 
            _userManager = userManager;
        }

        protected async Task<IdentityUser> GetUserIdAsync() => await _userManager.GetUserAsync(this.User);
    }
}