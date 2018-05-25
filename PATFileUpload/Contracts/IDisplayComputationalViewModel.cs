using System.Collections.Generic;

namespace PATFileUpload
{

  public interface IDisplayComputationalViewModel
  {
    List<ComputationModel> Computations { get; set; }

    void UpdateComputations(ComputationModel model);
  }
}
