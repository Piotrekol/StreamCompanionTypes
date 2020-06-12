using System;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces
{
    public interface IFirstRunControl
    {
        event EventHandler<FirstRunCompletedEventArgs> Completed;
    }
}