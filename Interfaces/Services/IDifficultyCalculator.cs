using CollectionManager.DataTypes;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces.Services
{
    public interface IDifficultyCalculator
    {
        IBeatmap ApplyMods(IBeatmap map, Mods mods);
    }
}