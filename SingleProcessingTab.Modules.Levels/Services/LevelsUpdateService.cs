using System;
using SingleProcessingTab.Spike.Core;
using SingleProcessingTab.Spike.Services;

namespace SingleProcessingTab.Modules.Levels.Services;

public class LevelsUpdateService: BaseUpdateService<UpdateData,Level>
{
    private readonly Level level = new(2);
   
    protected override UpdateData CreateAndInitializeT()
    {
        return new UpdateData(level, DateTime.UtcNow.ToLongTimeString());

    }
    
}