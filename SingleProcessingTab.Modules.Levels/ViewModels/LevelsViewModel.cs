using System;
using System.Diagnostics;
using Prism.Events;
using Prism.Regions;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Core.Events;
using SingleProcessingTab.Spike.Core.Mvvm;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Modules.Levels.ViewModels
{
    public class LevelsViewModel: BaseViewModel<UpdateData, Level>
    {
        private readonly IEventAggregator eventAggregator;
        private UpdateData localData;

        public string TabHeaderText { get; set; } = "Levels";
        
        public UpdateData LocalData
        {
            get => localData;
            set => SetProperty(ref localData, value);
        
        }

        public LevelsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IUpdateService<UpdateData, Level> updateService) : 
            base(regionManager, updateService)
        {
            this.eventAggregator = eventAggregator;

        }

        protected override void OnDataReceived(UpdateData data)
        {
            LocalData = data;
            eventAggregator.GetEvent<ModuleDataPublishedEvent>().Publish(data);

        }

        protected override void OnProcessingStateChanged(bool isProcessing)
        {
            Trace.WriteLine($"Processing for {LocalData?.Level.Id} is {isProcessing}");

        }
    }
}
