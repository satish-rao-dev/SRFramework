using SRFramework.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SRFramework.WPF.MVVM.Converters
{
    public class MessageTypeToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StatusMessageType messageType = (StatusMessageType)value;
            if (messageType == StatusMessageType.Error)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else if(messageType == StatusMessageType.Warning) {
                return new SolidColorBrush(Colors.Orange);
            }
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
