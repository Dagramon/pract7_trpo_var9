using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract7.Validation
{
    public class FilterValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? str = value as string;
            if (str.Length < 2)
            {
                return new ValidationResult(false, "Строка не может быть из 1 символа");
            }
            if (str.Length > 100)
            {
                return new ValidationResult(false, "Строка не может быть больше 100 символов");
            }
            return ValidationResult.ValidResult;
        }
    }
}
