using System.Globalization;
using System.Windows.Controls;

namespace Macros_Manager.View.ValidationRules
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object a_value, CultureInfo a_cultureInfo)
        {
            return string.IsNullOrWhiteSpace((a_value ?? "").ToString())
                ? new ValidationResult(false, "Field is required.")
                : ValidationResult.ValidResult;
        }
    }

    public class MacroControllerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object a_value, CultureInfo a_cultureInfo)
        {
            return string.IsNullOrWhiteSpace((a_value ?? "").ToString())
                ? new ValidationResult(false, "Field is required.")
                : ValidationResult.ValidResult;
        }
    }
}
