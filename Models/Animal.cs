using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesarrolloApiEF.Models
{
    public class Animal: IValidatableObject
    {
        [Key]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "The 'Name' field is required")]
        [StringLength(50, ErrorMessage = "The 'Name' field cannot exceed 50 characters.")]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "The 'Price' field must be greater than 0.")]
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string Comments { get; set; }
        
        [ForeignKey("BreedId")]
        public int BreedId { get; set; }

        public Breed Breed { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            if (dbContext.animals.Any(a => a.Name == this.Name && a.AnimalId != this.AnimalId))
            {
                yield return new ValidationResult("The 'Name' field must be unique.", new[] { nameof(Name) });
            }
            yield break;
        }
    }
}
