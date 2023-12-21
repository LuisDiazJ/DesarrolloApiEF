using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesarrolloApiEF.Models
{
    public class AnimalBreed
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Breed")]
        public int BreedsId { get; set; }


        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
    }
}
