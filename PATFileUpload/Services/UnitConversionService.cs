using static PATFileUpload.PATRepository;

namespace PATFileUpload
{
  class UnitConversionService
  {
    private static UnitConversionService _instance = null;

    public static UnitConversionService Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new UnitConversionService();
        }
        return _instance;
      }
    }

    private UnitConversionService()
    {
    }

    public double GetConvertedValue(MeasuringUnits pNewUnit, MeasuringUnits pOldUnit,  double pDataPoint)
    {
      switch (pOldUnit)
      {
        case MeasuringUnits.Meter:

          switch (pNewUnit)
          {
            case MeasuringUnits.Meter:
              return pDataPoint;
            case MeasuringUnits.Feet:
              return MetersToFeet(pDataPoint);
          }
          break;
        case MeasuringUnits.Feet:
          switch (pNewUnit)
          {
            case MeasuringUnits.Meter:
              return FeetToMeters(pDataPoint);
            case MeasuringUnits.Feet:
              return pDataPoint;
          }
          break;
      }
      return 0;
    }


    private double MetersToFeet(double pDataPoint)
    {
      return pDataPoint / 0.304800610;
    }

    private static double FeetToMeters(double pDataPoint)
    {
      return pDataPoint * 0.304800610;
    }

  }
}
