using System;
using System.Globalization;
using System.Windows.Data;

namespace EllaRecipes.AdminPanel.Converters
{
    public class BoolToEyeIconConverter : IValueConverter
    {
        public BoolToEyeIconConverter() { }

        // Segoe MDL2 Assets: \uE522 = eye, \uE523 = eye-off
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is bool b && b) ? "\uE523" : "\uE522";
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
