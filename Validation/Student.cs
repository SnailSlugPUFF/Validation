using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation
{
    public class Student : IValidatable
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(1, 4)]
        public int StudyYear { get; set; }
        public Student(string name, int studyyear)
        {
            Name = name;
            StudyYear = studyyear;
        }

        public ICollection<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, validationContext, results, true);
            return results;
        }
    }
}