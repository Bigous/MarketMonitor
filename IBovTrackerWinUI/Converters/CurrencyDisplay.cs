using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace IBovTrackerWinUI.Converters;

internal class CurrencyDisplay : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, string language)
	{
		if (value is double valDbl)
		{
			return valDbl.ToString("C", CultureInfo.CurrentUICulture);
		}
		return null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language)
	{
		throw new NotImplementedException();
	}
}
