using System;
using System.Globalization;
using System.Windows.Data;

namespace FF1
{
	class ItemConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Info.Instance().Search(Info.Instance().Items, (uint)value)?.Name;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return "";
		}
	}
}
