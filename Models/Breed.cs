using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesarrolloApiEF.Models
{
    public class Breed
    {
        [Key]
        public int BreedsId { get; set; }
        public string BreedType { get; set; }
    }
}
