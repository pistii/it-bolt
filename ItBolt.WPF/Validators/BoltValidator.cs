using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ItBolt.WPF.Validators
{
    class BoltValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? valueText = value.ToString();
            if (!string.IsNullOrWhiteSpace(valueText))
            {
                if (valueText.Length < 3)
                {
                    return new ValidationResult(false, "Túl rövid");
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "A mező kitöltése kötelező.");
        }
    }
}
