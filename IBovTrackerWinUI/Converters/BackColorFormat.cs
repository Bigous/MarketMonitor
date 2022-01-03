using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBovTrackerWinUI.Converters;

internal class BackColorFormat : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, string language)
	{
		if (value is double valDbl)
		{
			if (Math.Abs(valDbl) > 0.05)
			{
				SolidColorBrush brush = new();
				brush.Color = Colors.Yellow;
			}
		}
		return null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language)
	{
		throw new NotImplementedException();
	}
}
