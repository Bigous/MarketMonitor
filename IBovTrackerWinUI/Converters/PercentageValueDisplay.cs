using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBovTrackerWinUI.Converters;

internal class PercentageValueDisplay : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, string language)
	{
		if (value == null)
			return null;

		if (value is double valDbl)
		{
			return (valDbl / 100.0).ToString("0.00%");
		}

		if (value is int valInt)
		{
			return (valInt / 100.0).ToString("0.00%");
		}
		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language)
	{
		throw new NotImplementedException();
	}
}
