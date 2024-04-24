using System;
using System.ComponentModel.DataAnnotations;

namespace Article.Web.Utility
{
    public class Validations
    {
        public class NotFutureDateAttribute : ValidationAttribute
        {
            public NotFutureDateAttribute() : base("The date cannot be in the future.")
            {
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime dateTimeValue)
                {
                    if (dateTimeValue > DateTime.Now)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}
