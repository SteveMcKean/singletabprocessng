using Prism.Regions;
using SingleProcessingTab.Spike.Core.Mvvm;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Spike.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string message;
        
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
            
        }

        public string TabHeaderText { get; set; } = "Tab A";
        

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
            
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
            
        }
    }
}
