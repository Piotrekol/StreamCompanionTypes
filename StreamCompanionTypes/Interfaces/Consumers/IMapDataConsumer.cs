using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces.Consumers
{
    public interface IMapDataConsumer
    {
        void SetNewMap(IMapSearchResult map);
    }
}