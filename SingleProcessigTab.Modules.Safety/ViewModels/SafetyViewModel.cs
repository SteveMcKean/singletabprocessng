using Prism.Events;
using Prism.Regions;
using SingleProcessingTab.Spike.Core.Events;
using SingleProcessingTab.Spike.Core.Mvvm;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Services.Interfaces;
using System.Diagnostics;

namespace SingleProcessingTab.Modules.Safety.ViewModels
{
    public class SafetyViewModel : BaseViewModel<UpdateData, Level>
    {
        private readonly IEventAggregator eventAggregator;
        private UpdateData localData;

        public string TabHeaderText { get; set; } = "Safety";

        public string Message { get; set; } = "Safety View Selected";

        public UpdateData LocalData
        {
            get => localData;
            set => SetProperty(ref localData, value);

        }

        public SafetyViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IUpdateService<UpdateData, Level> updateService) :
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
                eventAggregator.GetEvent<ResetModuleDataPublishedEvent>().Publish(updatedData);

            }

            Trace.WriteLine($"Processing for {LocalData?.Level.Id} is {isProcessing}");

        }
    }
}
