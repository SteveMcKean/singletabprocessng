using System;
using System.Collections.Generic;

namespace SingleProcessingTab.Spike.Core;

public class UpdateData
{
    // Readonly properties to maintain immutability
    public Level Level { get; }
    public string Value { get; }
    public bool IsActive { get; }

    // Constructor to initialize properties
    public UpdateData(Level level, string value, bool isActive = false)
    {
        Level = level;
        Value = value;
        IsActive = isActive;

    }

    // Overriding Equals and GetHashCode for value-based equality (optional)
    public override bool Equals(object obj)
    {
        return obj is UpdateData other &&
               EqualityComparer<Level>.Default.Equals(Level, other.Level) &&
               Value == other.Value &&
               IsActive == other.IsActive;

    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Level, Value, IsActive);

    }

    // Implementation of deconstruction (optional)
    public void Deconstruct(out Level level, out string value, out bool isActive)
    {
        level = Level;
        value = Value;
        isActive = IsActive;

    }
}
