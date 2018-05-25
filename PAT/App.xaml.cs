using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PAT
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      // base.OnStartup(e);

      //Initializing the bootstrapper class. This bootstrapper is the glue between the application and prism services.
      var bootstrapper = new Bootstrapper();
      bootstrapper.Run();
    }
  }
}
