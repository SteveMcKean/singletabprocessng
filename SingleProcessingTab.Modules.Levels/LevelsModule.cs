using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SingleProcessingTab.Modules.Levels.Services;
using SingleProcessingTab.Modules.Levels.Views;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Modules.Levels
{
    public class LevelsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(LevelsView));
            
            containerProvider.Resolve<IUpdateService<UpdateData, Level>>();

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LevelsView>();
            containerRegistry.RegisterSingleton<IUpdateService<UpdateData, Level>, LevelsUpdateService>();

        }
    }
}