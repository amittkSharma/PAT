using System.Collections.Generic;
using System.ComponentModel;

namespace PATFileUpload
{
  public class PATRepository : IPATRepository
  {
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum MeasuringUnits
    {
      [Description("Cubic Meter")]
      Meter = 0,
      [Description("Cubic Feet")]
      Feet= 1,
    }
    
    public string[] DepthDataPoints { get ; set; }

    public MeasuringUnits SelectedMeasuringUnit { get; set; }

    public List<HorizonConfigurationModel> GetHorizonConfigurations()
    {
      var list = new List<HorizonConfigurationModel>();
      list.Add(new HorizonConfigurationModel()
      {
        HorizonName = "Top Horizon",
        CellLength = 200,
        CellWidth = 200,
        DepthFactor = 0
      });
      list.Add(new HorizonConfigurationModel()
      {
        HorizonName = "Base Horizon",
        CellLength = 200,
        CellWidth = 200,
        DepthFactor = UnitConversionService.Instance.GetConvertedValue(MeasuringUnits.Feet, MeasuringUnits.Meter, 100)   // 100 meter to feet - 328
      });
      list.Add(new HorizonConfigurationModel()
      {
        HorizonName = "Fluid Contact",
        CellLength = 200,
        CellWidth = 200,
        DepthFactor = UnitConversionService.Instance.GetConvertedValue(MeasuringUnits.Feet, MeasuringUnits.Meter, 3000) // 3000 meter to feet - 984
      });

      return list;
    }
  }
}
