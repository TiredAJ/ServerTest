using Microsoft.AspNetCore.Mvc;
using ServerTest.Models;

namespace ServerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> GetAllHeroes()
        {
            List<Superhero> Heroes =
                [new() { Description = "From Accountown", ID = 1, Name = "John", Place = "Accounttown" }];

            return Ok(Heroes);
        }
    }
}