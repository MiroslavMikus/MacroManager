using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Macros_Manager.Tools;

namespace Macros_Manager.UI.ValidationRules
{
    public class FutureTimeValidationRule : ValidationRule
    {
        public DateCheck DateToCheck { get; set; }

        public override ValidationResult Validate(object a_value, CultureInfo a_cultureInfo)
        {

            DateTime inputTime;

            if (CheckDateValidation.Check(a_value,out inputTime))
                return new ValidationResult(false, "Invalid date");

            var date = DateToCheck.Date;

            var resultDate = inputTime.CreateDateFromTime(date.Year, date.Month, date.Day);

            return resultDate < DateTime.Now ? new ValidationResult(false, "Time is in past") : new ValidationResult(true,null);
        }
    }
}