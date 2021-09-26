using System.Threading;
using System.Threading.Tasks;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces.Consumers
{
    public interface IMapDataConsumer
    {
        Task SetNewMapAsync(IMapSearchResult map, CancellationToken cancellationToken);
    }
}