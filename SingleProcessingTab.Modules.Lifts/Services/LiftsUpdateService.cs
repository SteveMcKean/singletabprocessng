using System;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Services;

namespace SingleProcessingTab.Modules.Lifts.Services;

public class LiftsUpdateService: BaseUpdateService<UpdateData,Level>
{
    private readonly Level level = new(1);
    
    protected override UpdateData CreateAndInitializeT()
    {
        return new UpdateData(level, DateTime.UtcNow.ToLongTimeString());

    }
}