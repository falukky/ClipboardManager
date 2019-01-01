using System;
using System.Globalization;
using System.Windows.Data;

namespace ClipboardManager.Classes.Convertors
{
    public class ClipboardItemIndexToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int index = (int)value;
            switch (index)
            {
                case 1:
                    return "pack://application:,,,/Resources/1.ico";

                case 2:
                    return "pack://application:,,,/Resources/2.ico";

                case 3:
                    return "pack://application:,,,/Resources/3.ico";

                case 4:
                    return "pack://application:,,,/Resources/4.ico";

                case 5:
                    return "pack://application:,,,/Resources/5.ico";

                case 6:
                    return "pack://application:,,,/Resources/6.ico";

                case 7:
                    return "pack://application:,,,/Resources/7.ico";

                case 8:
                    return "pack://application:,,,/Resources/8.ico";

                case 9:
                    return "pack://application:,,,/Resources/9.ico";

                default:
                    return "pack://application:,,,/Resources/notes2.ico";                                        
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
