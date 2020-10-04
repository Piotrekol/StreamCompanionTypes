using System.Threading;
using System.Threading.Tasks;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces.Sources
{
    public interface ITokensSource
    {
        /// <summary>
        /// Tokens should get updated upon calling this method<para/>
        /// Use static <see cref="Tokens.CreateTokenSetter"/> to create method for generating and updating tokens
        /// </summary>
        /// <param name="map"></param>
        /// <param name="cancellationToken"></param>
        Task CreateTokensAsync(IMapSearchResult map, CancellationToken cancellationToken);
    }
}