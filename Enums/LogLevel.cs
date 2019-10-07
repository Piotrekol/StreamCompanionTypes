using System;

namespace StreamCompanionTypes.Enums
{
    [Flags]
    public enum LogLevel
    {
        Disabled = 0, Basic = 1, Advanced = 2, Debug = 3, Error = 4
    }

}