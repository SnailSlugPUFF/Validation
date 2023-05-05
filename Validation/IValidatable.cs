using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation
{
    public interface IValidatable
    {
        ICollection<ValidationResult> Validate(ValidationContext validationContext);
    }
}