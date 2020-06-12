using System.Collections.Generic;
using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Interfaces.Sources;

namespace StreamCompanionTypes.Interfaces
{
    public interface IFirstRunControlProvider
    {
        List<IFirstRunControl> GetFirstRunUserControls();
    }
}