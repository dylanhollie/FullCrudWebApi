﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullCrudWebAPI_Dot8.Entities;

namespace FullCrudWebAPI_Dot8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHeros()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                }
            };
            return Ok(heroes);
        }
    }
}
