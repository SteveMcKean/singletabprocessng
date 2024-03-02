using Prism.Mvvm;
using SingleProcessingTab.Spike.Core;

namespace SingleProcessingTab.Spike.ViewModels;

public class UpdateDataViewModel : BindableBase
{
    private UpdateData data;

    public UpdateData UpdateData
    {
        get => data;
        set
        {
            if (Equals(value, data))
                return;

            data = value;

            RaisePropertyChanged();
            RaisePropertyChanged(nameof(Value));
            RaisePropertyChanged(nameof(IsActive));
            RaisePropertyChanged(nameof(LevelId));

        }
    }

    public int LevelId
    {
        get => UpdateData.Level.Id;
        set
        {
            var level = new Level(value); // Assuming Level can be initialized with Id
            UpdateData = new UpdateData(level, UpdateData.Value, UpdateData.IsActive);

            RaisePropertyChanged();

        }
    }

    public string Value
    {
        get => UpdateData.Value;
        set
        {
            UpdateData = new UpdateData(UpdateData.Level, value, UpdateData.IsActive);
            RaisePropertyChanged();

        }
    }

    public bool IsActive
    {
        get => UpdateData.IsActive;
        set
        {
            UpdateData = new UpdateData(UpdateData.Level, UpdateData.Value, value);
            RaisePropertyChanged();

        }
    }

    public UpdateDataViewModel(UpdateData data)
    {
        UpdateData = data;

    }
}