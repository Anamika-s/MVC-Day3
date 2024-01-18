using System.ComponentModel.DataAnnotations;

namespace MVC_Day3.Models
{
    public class JoingYearVaildator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                int? JoingYear = (int?)value;
                if (JoingYear.HasValue)
                {
                    if(JoingYear < 10)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult(ErrorMessage ?? "Joining Year should be less than 10");
            //return base.IsValid(value, validationContext);
        }
    }
}
