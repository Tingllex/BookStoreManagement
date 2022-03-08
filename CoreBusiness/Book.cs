using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreBusiness
{
    public class Book : IValidatableObject
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Title is too long.")]
        [MyValidation(ErrorMessage =
            "ERROR ERROR ERROR ERROR ERROR ERROR ERROR ERROR ERROR ")]
        public string Title { get; set; }
        [Required]
        [Range(1800, 2022, ErrorMessage = "Publication Year should be between 1800 and 2022")]
        public int? PublicationYear { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Price { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public int? GenreId { get; set; }
        public Genre Genres { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price < 50 && PublicationYear < 1850)
            {
                yield return new ValidationResult("Price should be higher than 50 if year of publication is below 1850");
            }
        }
    }

    public class MyValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string title = Convert.ToString(value);
            if (title!="easter egg")
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("ERROR ERROR ERROR ERROR ERROR ERROR ERROR ERROR ERROR ");
            }
        }
    }

    
}
