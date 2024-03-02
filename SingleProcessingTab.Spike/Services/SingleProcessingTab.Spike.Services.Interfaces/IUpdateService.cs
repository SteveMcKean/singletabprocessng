using System;

namespace SingleProcessingTab.Spike.Services.Interfaces
{
    public interface IUpdateService<out T, TLevel> where T: class where TLevel : class
    {
        // Observable representing the processing state
        IObservable<bool> ProcessingObservable { get; }

        // Observable representing the UI update data
        IObservable<T> UiDataObservable { get; }

        // Method to start processing
        void StartProcessing();

        // Method to pause processing
        void PauseProcessing();
        
    }
}