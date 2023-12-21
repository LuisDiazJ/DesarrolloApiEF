using Microsoft.EntityFrameworkCore;
using DesarrolloApiEF.Models;

namespace DesarrolloApiEF
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }
        
        public DbSet<Animal> animals { get; set; }
        public DbSet<Breed> breeds { get; set; }
        public DbSet<AnimalBreed> animalsbreeds { get; set; }
    }
}
