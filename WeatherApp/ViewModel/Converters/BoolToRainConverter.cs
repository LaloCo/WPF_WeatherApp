using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace WeatherApp.ViewModel.Converters
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool hasPrecipitation = (bool)value;

            if (hasPrecipitation)
                return "Currently raining";
            return "Currently not raining";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string rainingStatus = (string)value;

            if (rainingStatus == "Currently raining")
                return true;
            return false;
        }
    }
}
