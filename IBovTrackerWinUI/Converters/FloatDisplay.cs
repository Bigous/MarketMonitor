using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBovTrackerWinUI.Converters;

internal class FloatDisplay : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, string language)
	{
		if (value == null)
			return null;

		if (value is double valDbl)
		{
			return valDbl.ToString("#", CultureInfo.CurrentUICulture);
		}

		if (value is int valInt)
		{
			return valInt.ToString("#", CultureInfo.CurrentUICulture);
		}
		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language)
	{
		throw new NotImplementedException();
	}
}
