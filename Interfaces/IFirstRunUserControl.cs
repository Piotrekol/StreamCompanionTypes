using System;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces
{
    public interface IFirstRunUserControl
    {
        event EventHandler<FirstRunCompletedEventArgs> Completed;
    }
}