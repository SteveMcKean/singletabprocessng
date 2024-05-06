using System;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Spike.Services
{
    public abstract class BaseUpdateService<T, TLevel> : IUpdateService<T, TLevel>
        where T : class where TLevel : class
    {
        private CancellationTokenSource cancellationTokenSource;

        // Observable representing the processing state
        private readonly BehaviorSubject<bool> processingSubject = new(false);

        // Observable representing the UI update data
        private readonly BehaviorSubject<T> uiDataSubject = new(default);

        protected abstract T CreateAndInitializeT();
    
        // Expose observables for external components to subscribe to
        public IObservable<bool> ProcessingObservable => processingSubject;

        public IObservable<T> UiDataObservable => uiDataSubject;


        public void StartProcessing()
        {
            cancellationTokenSource = new CancellationTokenSource();

            Task.Run(async () =>
                {
                    try
                    {
                        while (!cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            processingSubject.OnNext(true);
                            uiDataSubject.OnNext(CreateAndInitializeT());

                            await Task.Delay(1000, cancellationTokenSource.Token); // Pass cancellation token

                        }
                    }
                    catch (TaskCanceledException)
                    {

                    }

                }, cancellationTokenSource.Token);

        }

        // Method to pause processing, updated comment. New comment
        public void PauseProcessing()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();

            processingSubject.OnNext(false);

        }

        private void Dispose(bool isDisposing)
        {
            
        }
    }

}