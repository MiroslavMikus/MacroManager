using System;
using System.Globalization;
using System.Windows.Controls;

namespace Macros_Manager.View.ValidationRules
{
    public class FutureDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object a_value, CultureInfo a_cultureInfo)
        {
            DateTime inputTime;

            if (CheckDateValidation.Check(a_value, out inputTime))
                return new ValidationResult(false, "Invalid date"); ;

            return inputTime.Date < DateTime.Now.Date
                ? new ValidationResult(false, "Future date required")
                : ValidationResult.ValidResult;
        }
    }
}
