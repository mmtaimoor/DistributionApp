using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DistributionApp.Convertors
{
    public class CalculateTotalPrice : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var price = values[0] as decimal?;
            var qty = values[1] as int?;
            
            if (price != null && qty != null)
            {
                return (price.GetValueOrDefault() * qty.GetValueOrDefault()).ToString();
            }
                
        
            return string.Empty;
            //throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
