using System;
using System.Windows.Data;

namespace PATFileUpload
{
  public class SingleUnitToVolumeUnitConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      switch (value.ToString().ToLower())
      {
        case "feet":
          return "cubic feet";
        case "meter":
          return "cubic meter";
        case "barrel":
          return "barrel";
        default:
          return "cubic feet";
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new Exception("No implemented");
    }
  }
}
