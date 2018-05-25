using System;
using System.Collections.Generic;

namespace PATFileUpload
{
  public interface IPATRepository
  {
    List<HorizonConfigurationModel> GetHorizonConfigurations();

    String[] DepthDataPoints { get; set; }
  }
}
