using System;
using System.Collections.ObjectModel;
using Prism.Events;
using Prism.Mvvm;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Core.Events;

namespace SingleProcessingTab.Spike.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";

        private UpdateDataViewModel levelsData;
        private UpdateDataViewModel liftsData;
        private UpdateDataViewModel safetyData;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
            
        }

        public UpdateDataViewModel LevelsData
        {
            get => levelsData;
            set => SetProperty(ref levelsData, value);

        }

        public UpdateDataViewModel LiftsData
        {
            get => liftsData;
            set => SetProperty(ref liftsData, value);

        }

        public UpdateDataViewModel SafetyData
        {
            get => safetyData;
            set => SetProperty(ref safetyData, value);

        }

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<ModuleDataPublishedEvent>().Subscribe(d =>
                {
                    if(d is { Level.Id: 1 })
                        LevelsData = new UpdateDataViewModel(d);
                    else if (d is { Level.Id: 2})
                        LiftsData = new UpdateDataViewModel(d);
                    else if (d is { Level.Id: 3})
                        SafetyData = new UpdateDataViewModel(d);
                    
                }, ThreadOption.UIThread);

            eventAggregator.GetEvent<ResetModuleDataPublishedEvent>().Subscribe(d =>
                {
                    if (d is { Level.Id: 1 })
                        LevelsData = new UpdateDataViewModel(d);
                    else if (d is { Level.Id: 2 })
                        LiftsData = new UpdateDataViewModel(d);
                    else if (d is { Level.Id: 3 })
                        SafetyData = new UpdateDataViewModel(d);

                }, ThreadOption.UIThread);

        }
        
    }
}
