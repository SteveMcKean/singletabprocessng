using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Modules.ModuleName.Views;

namespace SingleProcessingTab.Spike.Modules.ModuleName
{
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager regionManager;

        public ModuleNameModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            
        }
    }
}