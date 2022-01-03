using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBovTrackerWinUI.Converters;

internal class PositiveOrNegativeFormat : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, string language)
	{
		if (value is double valDbl)
		{
			SolidColorBrush brush = new();
			if (valDbl >= 0)
				brush.Color = Colors.Cyan;
				//brush.Color = typeof(Colors).GetProperty(parameter[0])?.GetValue(null, Colors.Cyan);
			else
				brush.Color = Colors.Red;
			return brush;
		}
		return null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language)
	{
		throw new NotImplementedException();
	}
}
