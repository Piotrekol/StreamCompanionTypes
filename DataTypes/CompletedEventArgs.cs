using System;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes
{
    public class FirstRunCompletedEventArgs : EventArgs
    {
        public FirstRunStatus ControlCompletionStatus { get; set; }
    }
}