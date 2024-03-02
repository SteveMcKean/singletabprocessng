using System.Diagnostics;
using Prism.Events;
using Prism.Regions;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Core.Events;
using SingleProcessingTab.Spike.Core.Mvvm;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Modules.Lifts.ViewModels
{
    public class LiftsViewModel : BaseViewModel<UpdateData, Level>
    {
        private readonly IEventAggregator eventAggregator;
        private UpdateData localData;

        public string TabHeaderText { get; set; } = "Lifts";

        public string Message { get; set; } = "Lifts View Selected";

        public UpdateData LocalData
        {
            get => localData;
            set => SetProperty(ref localData, value);

        }

        public LiftsViewModel(IRegionManager regionManager, IUpdateService<UpdateData, Level> updateService, IEventAggregator eventAggregator)
            : base(regionManager, updateService)
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
                eventAggregator.GetEvent<ResetModuleDataPublishedEvent>().Publish(updatedData);

            }

            Trace.WriteLine($"Processing for {LocalData?.Level.Id} is {isProcessing}");

        }
    }
}
