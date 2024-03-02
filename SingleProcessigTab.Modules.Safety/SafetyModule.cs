using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SingleProcessingTab.Modules.Safety.Services;
using SingleProcessingTab.Modules.Safety.Views;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Modules.Safety
{
    public class SafetyModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(SafetyView));

            containerProvider.Resolve<IUpdateService<UpdateData, Level>>();

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SafetyView>();
            containerRegistry.RegisterSingleton<IUpdateService<UpdateData, Level>, SafetyUpdateService>();
        }
    }
}