﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ItBolt.WPF.Validators
{
    class EszkozRaktarkeszletValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int.TryParse(value.ToString(), out int number);

            if (number != 0)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "A mező kitöltése kötelező.");
        }
    }
}
