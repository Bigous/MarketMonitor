using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBovTrackerWinUI.Converters;

public class StringFormat : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, string language)
	{
		if (parameter == null)
			return value;
		return string.Format(parameter.ToString(), value);
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language)
	{
		throw new NotImplementedException();
	}
}
