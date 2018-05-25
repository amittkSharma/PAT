using Microsoft.Practices.Unity;
using PATCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using static PATFileUpload.PATRepository;

namespace PATFileUpload
{
  public class HorizonConfigurationsViewModel : ViewModelBase, IHorizonConfigurationsViewModel
  {
    private IPATRepository _repo;
    private IDisplayComputationalViewModel _displayComputationModel;
    public HorizonConfigurationsViewModel(IUnityContainer unityContainer)
    {
      _repo = unityContainer.Resolve<IPATRepository>();
      _displayComputationModel = unityContainer.Resolve<IDisplayComputationalViewModel>();
      HorizonConfirgurations = _repo.GetHorizonConfigurations();
    }

    public IList<MeasuringUnits> AllMeasuringUnits
    {
      get
      {
        return Enum.GetValues(typeof(MeasuringUnits)).Cast<MeasuringUnits>().ToList<MeasuringUnits>();
      }
    }

    public MeasuringUnits SelectedMeasuirngUnit
    {
      get { return _selectedMeasuringUnit; }
      set
      {
        _oldMeasuringUnit = _selectedMeasuringUnit;
        _selectedMeasuringUnit = value;
        OnPropertyChanged("SelectedMeasuirngUnit");
      }
    }
    private MeasuringUnits _selectedMeasuringUnit = MeasuringUnits.Feet;
    private MeasuringUnits _oldMeasuringUnit = MeasuringUnits.Feet;

    public List<HorizonConfigurationModel> HorizonConfirgurations
    {
      get { return _horizonConfigs; }
      set
      {
        _horizonConfigs = value;
        OnPropertyChanged("HorizonConfirgurations");
      }
    }
    private List<HorizonConfigurationModel> _horizonConfigs;

    public ICommand ComputeCommand
    {
      get
      {
        return new RelayCommand(param => ComputeVolume(), param => true);
      }
    }

    private void ComputeVolume()
    {
      var dataPoints = _repo.DepthDataPoints;

      var topHorizonConfig = GetConfiguration("Top Horizon");
      var baseHorizonConfig = GetConfiguration("Base Horizon");
      var fluidContractConfig = GetConfiguration("Fluid Contact");

      var fluidContractVol = ComputeVolume(fluidContractConfig.DepthFactor, fluidContractConfig.CellLength, fluidContractConfig.CellWidth);

      var newComList = new List<ComputationModel>();

      var topHorizonVolume = CalculateHorizonVolume(dataPoints, topHorizonConfig);
      newComList.Add(new ComputationModel() {
        ComputationName = "Top Horizon",
        UnitName = SelectedMeasuirngUnit.ToString(),
        Volume = topHorizonVolume + fluidContractVol,
      });

      var baseHorizonVolume = CalculateHorizonVolume(dataPoints, baseHorizonConfig);

      newComList.Add(new ComputationModel()
      {
        ComputationName = "Base Horizon",
        UnitName = SelectedMeasuirngUnit.ToString(),
        Volume = baseHorizonVolume - fluidContractVol,
      });

      _displayComputationModel.Computations = newComList;
    }

    private HorizonConfigurationModel GetConfiguration(string configName)
    {
      var config = _repo.GetHorizonConfigurations().Find(x => x.HorizonName == configName);

      return config;
    }

    private double CalculateHorizonVolume(string[] dataPoints, HorizonConfigurationModel config)
    {

      try
      {
        var calculatedVol = new List<double>();
        var depthFactor = UnitConversionService.Instance.GetConvertedValue(SelectedMeasuirngUnit, _oldMeasuringUnit, config.DepthFactor);
        var cellLength = UnitConversionService.Instance.GetConvertedValue(SelectedMeasuirngUnit, _oldMeasuringUnit, config.CellLength);
        var cellWidth = UnitConversionService.Instance.GetConvertedValue(SelectedMeasuirngUnit, _oldMeasuringUnit, config.CellWidth);

        foreach (var point in dataPoints)
        {
          var dataPoint = UnitConversionService.Instance.GetConvertedValue(SelectedMeasuirngUnit, _oldMeasuringUnit, Convert.ToDouble(point));

          var pointVol = ComputeVolume((dataPoint + depthFactor), cellLength , cellWidth);

          calculatedVol.Add(pointVol);
        }

        Console.WriteLine("Config Name {0}", config.HorizonName);

        double totalVol = calculatedVol.Sum();

        return totalVol;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error occurred during comoutation and error is: {0}", ex.Message);

        return 0;
      }

    }

    private double ComputeVolume(double pDataPoint, double pCellLenght, double pCellWidth)
    {
      return pDataPoint * pCellLenght * pCellWidth;
    }
  }
}
