using System;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Services;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Modules.Lifts.Services;

public class LiftsUpdateService: BaseUpdateService<UpdateData,Level>
{
    private readonly Level level = new(1);

    // private CancellationTokenSource cancellationTokenSource;
    //
    // // Observable representing the processing state
    // private readonly BehaviorSubject<bool> processingSubject = new(false);
    //
    // // Observable representing the UI update data
    // private readonly BehaviorSubject<UpdateData> uiDataSubject = new(new UpdateData(1, ""));
    //
    //
    // // Expose observables for external components to subscribe to
    // public IObservable<bool> ProcessingObservable => processingSubject;
    // public IObservable<UpdateData> UiDataObservable => uiDataSubject;
    //
    // public void StartProcessing()
    // {
    //     cancellationTokenSource = new CancellationTokenSource();
    //
    //     Task.Run(async () =>
    //         {
    //             try
    //             {
    //                 while (!cancellationTokenSource.Token.IsCancellationRequested)
    //                 {
    //                     processingSubject.OnNext(true);
    //                     uiDataSubject.OnNext(new UpdateData(1, DateTime.UtcNow.ToLongTimeString()));
    //
    //                     await Task.Delay(1000, cancellationTokenSource.Token); // Pass cancellation token
    //
    //                 }
    //             }
    //             catch (TaskCanceledException)
    //             {
    //                 
    //             }
    //
    //         }, cancellationTokenSource.Token);
    //     
    // }
    //
    // // Method to pause processing
    // public void PauseProcessing()
    // {
    //     cancellationTokenSource.Cancel();
    //     cancellationTokenSource.Dispose();
    //     
    //     processingSubject.OnNext(false);
    //     
    // }

    protected override UpdateData CreateAndInitializeT()
    {
        return new UpdateData(level, DateTime.UtcNow.ToLongTimeString());

    }
}