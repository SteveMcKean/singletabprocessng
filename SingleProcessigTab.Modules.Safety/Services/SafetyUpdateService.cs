using System;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Services;

namespace SingleProcessingTab.Modules.Safety.Services;

public class SafetyUpdateService: BaseUpdateService<UpdateData,Level>
{
    private readonly Level level = new(3);

    protected override UpdateData CreateAndInitializeT()
    {
        return new UpdateData(level, DateTime.UtcNow.ToLongTimeString());

    }
}