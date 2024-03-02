using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Threading;
using Prism;
using Prism.Mvvm;
using Prism.Regions;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Spike.Core.Mvvm;

public abstract class BaseViewModel<T, TLevel> : BindableBase, IActiveAware where T : class where TLevel : class
{
    private readonly IRegionManager regionManager;
    private bool isActive;

    protected readonly IUpdateService<T, TLevel> UpdateService;


    public bool IsActive
    {
        get => isActive;
        set => SetProperty(ref isActive, value, OnIsActiveChanged);

    }

    public event EventHandler IsActiveChanged = delegate { };

    protected BaseViewModel(IRegionManager regionManager, IUpdateService<T, TLevel> updateService)
    {
        this.regionManager = regionManager;
        this.UpdateService = updateService;

        updateService.UiDataObservable
            .ObserveOn(new DispatcherSynchronizationContext())
            .Subscribe(Observer.Create<T>(OnDataReceived));
            
        updateService.ProcessingObservable.Subscribe(OnProcessingStateChanged);

    }

    protected BaseViewModel(IRegionManager regionManager)
    {
        this.regionManager = regionManager;

    }

    protected abstract void OnDataReceived(T data);

    protected abstract void OnProcessingStateChanged(bool isProcessing);

    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
        UpdateService.StartProcessing();

    }

    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {
        UpdateService.PauseProcessing();

    }

    private void OnIsActiveChanged()
    {
        if (IsActive)
            UpdateService.StartProcessing();
        else
            UpdateService.PauseProcessing();

        IsActiveChanged?.Invoke(this, EventArgs.Empty);

    }
}