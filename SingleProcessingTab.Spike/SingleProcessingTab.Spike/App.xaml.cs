using Prism.Ioc;
using Prism.Modularity;
using SingleProcessingTab.Spike.Modules.ModuleName;
using SingleProcessingTab.Spike.Services;
using SingleProcessingTab.Spike.Services.Interfaces;
using SingleProcessingTab.Spike.Views;
using System.Windows;
using SingleProcessingTab.Modules.Levels;
using SingleProcessingTab.Modules.Lifts;
using SingleProcessingTab.Modules.Safety;

namespace SingleProcessingTab.Spike
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
            moduleCatalog.AddModule<LevelsModule>();
            moduleCatalog.AddModule<LiftsModule>();
            moduleCatalog.AddModule<SafetyModule>();

        }
        
    }
}
