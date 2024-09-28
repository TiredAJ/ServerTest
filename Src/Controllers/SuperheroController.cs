using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerTest.Models;
using ServerTest.Service;

namespace ServerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : Controller
    {
        private readonly STDataContext Context;

        public SuperheroController(STDataContext _CTX)
        { Context = _CTX; }

        #region GET        
        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> GetAllHeroes()
        {
            List<Superhero> Heroes = await Context.Superheroes.ToListAsync();

            return Ok(Heroes);
        }
        
        [HttpGet("{_ID}")]
        public async Task<ActionResult<Superhero>> GetHero(int _ID)
        {
            Superhero? Hero = await Context.Superheroes.FindAsync(_ID);

            if (Hero is null)
            { return NotFound(); }
            
            return Ok(Hero);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<ActionResult<Superhero>> AddHero(Superhero _Hero)
        {
            var ReturnedSuperhero = await Context.Superheroes.AddAsync(_Hero);
            await Context.SaveChangesAsync();
            
            return Ok(ReturnedSuperhero.Entity);
        }
        #endregion

        #region PUT
        [HttpPut("{_ID}")]
        public async Task<ActionResult<Superhero>> UpdateHero(int _ID, Superhero _UpdatedHero)
        {
            var Hero = await Context.Superheroes.FindAsync(_ID);

            if (Hero is null)
            { return NotFound(); }

            Hero.Name = _UpdatedHero.Name;
            Hero.Description = _UpdatedHero.Description;
            Hero.Place = _UpdatedHero.Place;

            await Context.SaveChangesAsync();

            var NewHero = await Context.Superheroes.FindAsync(_ID);

            if (NewHero is null)
            { return NotFound(); }

            return Ok(NewHero);
        }
        #endregion

        #region Delete
        [HttpDelete("{_ID}")]
        public async Task<ActionResult<Superhero>> DeleteHero(int _ID)
        {
            var DBHero = await Context.Superheroes.FindAsync(_ID);

            if (DBHero is null)
            { return NotFound(); }

            var RemovedHero = Context.Superheroes.Remove(DBHero).Entity;

            await Context.SaveChangesAsync();

            return Ok(RemovedHero);
        }
        
        #endregion
    }
}