using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PATFileUpload;
using Prism.Modularity;
using System;
using System.Windows;

namespace PAT
{
  public class Bootstrapper: Prism.Unity.UnityBootstrapper
  {

    private readonly CallbackLogger _callbackLogger = new CallbackLogger();

    protected override DependencyObject CreateShell()
    {
      return null;
    }

    protected override void InitializeShell()
    {
      if (Shell != null && Shell is Window)
      {
        Application.Current.MainWindow = (Window)Shell;
        Application.Current.MainWindow.Show();
      }
    }

    protected override Prism.Modularity.IModuleCatalog CreateModuleCatalog()
    {
      // When using MEF, the existing Prism ModuleCatalog is still
      // the place to configure modules via configuration files.
      return new Prism.Modularity.ConfigurationModuleCatalog();
    }

    protected override void ConfigureContainer()
    {
      base.ConfigureContainer();

      this.Container.RegisterInstance<CallbackLogger>(this._callbackLogger);
    }

    protected override void ConfigureModuleCatalog()
    {
      Type moduleCType = typeof(PATComputeModule);
      ModuleCatalog.AddModule(
      new ModuleInfo()
      {
        ModuleName = moduleCType.Name,
        ModuleType = moduleCType.AssemblyQualifiedName,
      });
    }

  }
}
