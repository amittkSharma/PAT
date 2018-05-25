using Microsoft.Practices.Unity;
using PATCommon;
using System.Collections.Generic;
using static PATFileUpload.PATRepository;

namespace PATFileUpload
{
  public class DisplayComputationsViewModel : ViewModelBase, IDisplayComputationalViewModel
  {
    public DisplayComputationsViewModel(IUnityContainer unityContainer)
    {
      _computationModels = new List<ComputationModel>();

      _computationModels.Add(new ComputationModel()
      {
        ComputationName = "No Computations Available",
        UnitName = MeasuringUnits.Feet.ToString(),
        Volume = 0,
      });
    }


    public List<ComputationModel> Computations
    {
      get => _computationModels;
      set
      {
        _computationModels = value;
        OnPropertyChanged("Computations");
      }
    }
    private List<ComputationModel> _computationModels;

    public void UpdateComputations(ComputationModel model)
    {
      Computations.Add(model);
      OnPropertyChanged("Computations");

    }

  }
}
