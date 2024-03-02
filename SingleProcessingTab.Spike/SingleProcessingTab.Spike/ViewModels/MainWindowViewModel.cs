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
        private ObservableCollection<UpdateData> moduleData;
        private UpdateData levelsData;
        private UpdateData liftsData;
        private UpdateData safetyData;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
            
        }

        public ObservableCollection<UpdateData> ModuleData
        {
            get => moduleData;
            set => SetProperty(ref moduleData, value);
            
        }

        public UpdateData LevelsData
        {
            get => levelsData;
            set => SetProperty(ref levelsData, value);

        }

        public UpdateData LiftsData
        {
            get => liftsData;
            set => SetProperty(ref liftsData, value);

        }

        public UpdateData SafetyData
        {
            get => safetyData;
            set => SetProperty(ref safetyData, value);

        }

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            ModuleData = new ObservableCollection<UpdateData>();
            eventAggregator.GetEvent<ModuleDataPublishedEvent>().Subscribe(d =>
                {
                    if(d is { Level.Id: 1 })
                        LevelsData = d;
                    else if (d is { Level.Id: 2})
                        LiftsData = d;
                    else if (d is { Level.Id: 3})
                        SafetyData = d;

                }, ThreadOption.UIThread);

        }
        
    }
}
