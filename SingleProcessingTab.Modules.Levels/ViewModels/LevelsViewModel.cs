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

        public string Message { get; set; } = "Levels View Selected";

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
            if (data is null)
                return;

            LocalData = data;

            var updatedData = new UpdateData(data.Level, data.Value, IsActive);
            eventAggregator.GetEvent<ModuleDataPublishedEvent>().Publish(updatedData);

        }

        protected override void OnProcessingStateChanged(bool isProcessing)
        {
            if (!isProcessing && LocalData is not null)
            {
                var updatedData = new UpdateData(localData.Level, localData.Value, false);
                LocalData = updatedData;

                eventAggregator.GetEvent<ResetModuleDataPublishedEvent>().Publish(updatedData);

            }

            Trace.WriteLine($"Processing for {LocalData?.Level.Id} is {isProcessing}");

        }
    }
}
