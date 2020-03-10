using System;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces.Sources
{
    /// <summary>
    /// produces <see cref="MapSearchArgs"/> search requests for SC and other plugins to consume
    /// </summary>
    public interface IOsuEventSource
    {
        EventHandler<MapSearchArgs> NewOsuEvent { get; set; }
    }
}