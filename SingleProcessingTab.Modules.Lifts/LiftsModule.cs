using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SingleProcessingTab.Modules.Lifts.Services;
using SingleProcessingTab.Modules.Lifts.Views;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Modules.Lifts
{
    public class LiftsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<RegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(LiftsView));

            containerProvider.Resolve<IUpdateService<UpdateData, Level>>();
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LiftsView>();
            containerRegistry.RegisterSingleton<IUpdateService<UpdateData, Level>, LiftsUpdateService>();

        }
    }
}