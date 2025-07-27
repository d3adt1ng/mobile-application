using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Maui.Controls;


namespace assignment2425.Converters
{
    class RestaurantToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = value?.ToString()?.ToLowerInvariant();
            return name switch
            {
                "Dixy Chicken" => "dixys.png",
                "Aldi" => "aldi.png",
                "Asda" => "asda.png",
                "KFC" => "kfc.png",
                "McDonald's" => "maccies.png",
                "nandos" => "nandos.png",
                "tesco" => "tesco.png",
                _ => "foodgroceries.png"
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack is not implemented.");
        }
    }
}
