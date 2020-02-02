using CollectionManager.DataTypes;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces
{
    public interface IDifficultyCalculator
    {
        IBeatmap ApplyMods(IBeatmap map, Mods mods);
    }
}