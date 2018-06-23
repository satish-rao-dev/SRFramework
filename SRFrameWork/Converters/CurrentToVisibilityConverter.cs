using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SRFramework.WPF.MVVM.Converters
{
    public class CurrentToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isReverse = false;
            string param = parameter as string;
            if (string.Equals(param, "reverse", StringComparison.InvariantCultureIgnoreCase))
            {
                isReverse = true;
            }
            bool isCurrent = (bool)value;


            Visibility result = isReverse ? Visibility.Visible : Visibility.Collapsed;
            if (isCurrent) result = isReverse? Visibility.Collapsed:Visibility.Visible;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
