﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Macros_Manager.UI.Converters
{
    public class InvertBoolean : IValueConverter
    {
        public object Convert(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return !(bool) a_value;
        }

        public object ConvertBack(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return null;
        }
    }
}
