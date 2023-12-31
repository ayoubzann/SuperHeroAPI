﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> superHeroes= new List<SuperHero>
            {
                new SuperHero {Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place="New York City"
                },
                new SuperHero {Id = 2,
                Name = "Ironman",
                FirstName="Tony",
                LastName="Stark",
                Place="Malibu"
                }, 
            };

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {


            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroById(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if(hero is null) return NotFound("Sorry, this hero does not exist");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id,SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null) return NotFound("Sorry, this hero does not exist");

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            return Ok(superHeroes);
        }

    }
}
