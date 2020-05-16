using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiserMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiserMVC.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = MVSJwtTokens.AuthSchemes)]
    public class BackerController : Controller
    {
        [HttpGet]
        public List<string> GetBackers()
        {
            return new List<string>() { "Backer1", "Backer2" };
        }
        
    }
}