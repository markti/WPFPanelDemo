using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Data;

namespace MLB.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string hex = value.ToString();
            byte a, r, g, b;
            a = HexToInt(hex.Substring(0, 2));
            r = HexToInt(hex.Substring(2, 2));
            g = HexToInt(hex.Substring(4, 2));
            b = HexToInt(hex.Substring(6, 2));

            Color c = Color.FromArgb(a, r, g, b);

            return c;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        private byte HexToInt(string hex)
        {
            return byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }
        
    }
}
