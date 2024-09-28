using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerTest.DTOs;
using ServerTest.Models;
using ServerTest.Service;

namespace ServerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : Controller
    {
        private readonly STDataContext Context;
        private readonly IMapper Mapper;

        public SuperheroController(STDataContext _CTX, IMapper _Mapper)
        {
            Context = _CTX;
            Mapper = _Mapper;
        }

        #region GET        
        [HttpGet]
        public async Task<ActionResult<List<SuperheroDTO>>> GetAllHeroes()
        {
            List<Superhero> Heroes = await Context.Superheroes.ToListAsync();

            return Ok(Mapper.Map<List<SuperheroDTO>>(Heroes));
        }
        
        [HttpGet("{_ID}")]
        public async Task<ActionResult<SuperheroDTO>> GetHero(int _ID)
        {
            Superhero? Hero = await Context.Superheroes.FindAsync(_ID);

            if (Hero is null)
            { return NotFound(); }
            
            return Ok(Mapper.Map<SuperheroDTO>(Hero));
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<ActionResult<SuperheroDTO>> AddHero(SuperheroDTO _NewHero)
        {
            var MappedHero = Mapper.Map<Superhero>(_NewHero);
            
            var ReturnedSuperhero = await Context.Superheroes.AddAsync(MappedHero);
            await Context.SaveChangesAsync();
            
            return Ok(Mapper.Map<SuperheroDTO>(ReturnedSuperhero.Entity));
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