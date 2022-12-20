using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPE_App.Converter
{
    public class DateTimeToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime d)
            {
                return d.TimeOfDay;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan d)
            {
                if (parameter is DateTime dt)
                {
                    dt = dt.Date + d;
                    return dt.TimeOfDay;
                }
            }
            return value;
        }
    }
}
