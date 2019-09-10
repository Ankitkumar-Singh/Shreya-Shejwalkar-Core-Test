using System;
using System.ComponentModel.DataAnnotations;

namespace CandidateQualifications.Models
{
    public class ValidateDateRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) >= Convert.ToDateTime("1990/01/01") && Convert.ToDateTime(value) <= Convert.ToDateTime("2005/12/01"))
                return ValidationResult.Success;
            else
               return new ValidationResult("Date should be between 1990/01/01 and 2005/12/01");
        }
    }
}

