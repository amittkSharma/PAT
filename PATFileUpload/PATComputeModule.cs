using Microsoft.Practices.Unity;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace PATFileUpload
{
  public class PATComputeModule : IModule
  {

    private readonly IRegionViewRegistry _regionViewRegistry;

    private ILoggerFacade _loggerFacade;
    private readonly IUnityContainer _container;

    public PATComputeModule(IRegionViewRegistry registry, ILoggerFacade pLoggerFacade, IUnityContainer pContainer)
    {
      _regionViewRegistry = registry;

      _loggerFacade = pLoggerFacade;

      _container = pContainer;

      if (_loggerFacade == null)
        throw new Exception("Logger Not Implemented");

    }

    public void Initialize()
    {
       _container.RegisterType<IPATRepository, PATRepository>(new ContainerControlledLifetimeManager());

      _container.RegisterType<IFileUploadViewModel, FileUploadViewModel>();

      _container.RegisterType<IDisplayComputationalViewModel, DisplayComputationsViewModel>(new ContainerControlledLifetimeManager());

      _container.RegisterType<IHorizonConfigurationsViewModel, HorizonConfigurationsViewModel>();


      _regionViewRegistry.RegisterViewWithRegion("UploadRegion", typeof(Views.FileUploadView));

      _regionViewRegistry.RegisterViewWithRegion("ConfigurationRegion", typeof(Views.HorizonConfigurationsView));

      _regionViewRegistry.RegisterViewWithRegion("CRegion", typeof(Views.DisplayComputationsView));



    }
  }
}
