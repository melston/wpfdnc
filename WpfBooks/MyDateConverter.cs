using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfBooks
{
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class MyDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToString("yyyy/MM/dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            string strValue = value as string;
            DateTime resultDateTime;
            if (DateTime.TryParseExact(strValue, "yyyy/MM/dd", enUS,
                              DateTimeStyles.None, out resultDateTime))
            {
                return resultDateTime;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}

