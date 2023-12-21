using DesarrolloApiEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloApiEF.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AnimalsController(ApplicationDbContext context) 
        {
            this.context = context; 
        }

        private bool AnimalExists(int id)
        {
            return context.animals.Any(e => e.AnimalId == id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Animal>>> Get()
        {
            return await context.animals.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetById(int id)
        {
            var animal = await context.animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Animal animal)
        {
            context.Add(animal);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Animal animal)
        {
            if (id != animal.AnimalId)
            {
                return BadRequest(); 
            }

            context.Entry(animal).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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
            var animal = await context.animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound(); 
            }

            context.animals.Remove(animal);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("active-animals-by-breed")]
        public async Task<ActionResult<IEnumerable<object>>> GetActiveAnimalsByBreed()
        {
            var activeAnimalsByBreed = await context.animals
                .Where(a => a.IsActive) 
                .GroupBy(a => a.Breed.BreedType) 
                .Select(g => new
                {
                    BreedName = g.Key,
                    TotalActiveAnimals = g.Count()
                })
                .ToListAsync();

            return Ok(activeAnimalsByBreed);
        }

    }
}
