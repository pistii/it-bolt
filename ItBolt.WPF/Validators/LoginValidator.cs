
using System.Globalization;
using System.Windows.Controls;

namespace ItBolt.WPF.Validators
{
    public class LoginValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (value.ToString().Length >2)
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false, "Minimum 3 karakterből kell hogy álljon.");
        }
    } 
}
