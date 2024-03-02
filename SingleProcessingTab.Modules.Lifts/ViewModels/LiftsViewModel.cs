using System;
using System.Diagnostics;
using Prism;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Core.Events;
using SingleProcessingTab.Spike.Core.Mvvm;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Modules.Lifts.ViewModels
{
    public class LiftsViewModel : RegionViewModelBase, IActiveAware
    {
        private readonly IUpdateService<UpdateData, Level> updateService;
        private string message;
        private UpdateData localData;
        private bool isActive;


        
        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value, OnIsActiveChanged);
            
        }
        
        public event EventHandler IsActiveChanged = delegate{};
        

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
            
        }

        public string TabHeaderText { get; set; } = "Lifts";

        public UpdateData LocalData
        {
            get => localData;
            set => SetProperty(ref localData, value);
            
        }

        public DelegateCommand StartProcessingCommand { get; set; }
        public DelegateCommand PauseProcessingCommand { get; set; }
        
        public LiftsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, 
            IUpdateService<UpdateData, Level> updateService):base(regionManager)
        {
            this.updateService = updateService;

            updateService.UiDataObservable.Subscribe(data =>
                {
                    LocalData = data;
                    eventAggregator.GetEvent<ModuleDataPublishedEvent>().Publish(LocalData);
                    
                });

            updateService.ProcessingObservable.Subscribe(x => Trace.WriteLine(x));
            Message = "Lifts View";

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            updateService.StartProcessing();
            
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            updateService.PauseProcessing();
            
        }

        private void OnIsActiveChanged()
        {
            if (IsActive)
                updateService.StartProcessing();
            else
                updateService.PauseProcessing();

            IsActiveChanged?.Invoke(this, EventArgs.Empty);
            
        }

    }
}
