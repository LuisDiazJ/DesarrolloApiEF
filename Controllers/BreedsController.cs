using DesarrolloApiEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloApiEF.Controllers
{
    [Route("api/breeds")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BreedsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        private bool BreedExists(int id)
        {
            return context.breeds.Any(e => e.BreedsId == id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Breed>>> Get()
        {
            return await context.breeds.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetById(int id)
        {
            var breed = await context.breeds.FindAsync(id);

            if (breed == null)
            {
                return NotFound();
            }

            return breed;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Breed breed)
        {
            context.Add(breed);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Breed breed)
        {
            if (id != breed.BreedsId)
            {
                return BadRequest();
            }

            context.Entry(breed).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var breed = await context.breeds.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }
            context.breeds.Remove(breed);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
