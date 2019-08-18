using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bcc.Business.Helpers
{
    public class NonZeroAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be non-zero";
        }

        public override bool IsValid(object value)
        {
            var zero = Convert.ChangeType(0, value.GetType());
            return !zero.Equals(value);
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (IsValid(value))
                return new ValidationResult(null);
            else
                return new ValidationResult(
                    FormatErrorMessage(validationContext.MemberName)
                );
        }
    }
}
