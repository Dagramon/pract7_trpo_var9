using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract7.Validation
{
    public class NumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (decimal.TryParse(value?.ToString(), out decimal number))
            {
                if (number < 0)
                {
                    return new ValidationResult(false, "Число не может быть отрицательным");
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Введите корректное число");
        }
    }
}
