using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullCrudWebAPI_Dot8.Entities;
using FullCrudWebAPI_Dot8.Data;
using Microsoft.EntityFrameworkCore;

namespace FullCrudWebAPI_Dot8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SuperHeroController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var heroes = await _dataContext.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var heroes = await _dataContext.SuperHeroes.FindAsync(id);
            if (heroes is null)
            {
                return NotFound("Hero not found.");
            }
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _dataContext.SuperHeroes.Add(hero);
            await _dataContext.SaveChangesAsync();
            
            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
        {

            var dbHeroes = await _dataContext.SuperHeroes.FindAsync(updatedHero.Id);
            if (dbHeroes is null)
            {
                return NotFound("Hero not found.");
            }

            dbHeroes.Name = updatedHero.Name;
            dbHeroes.FirstName = updatedHero.FirstName;
            dbHeroes.LastName = updatedHero.LastName;
            dbHeroes.Place = updatedHero.Place;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {

            var dbHeroes = await _dataContext.SuperHeroes.FindAsync(id);
            if (dbHeroes is null)
            {
                return NotFound("Hero not found.");
            }

            _dataContext.SuperHeroes.Remove(dbHeroes);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }
    }
}
