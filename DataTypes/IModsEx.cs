using CollectionManager.DataTypes;

namespace StreamCompanionTypes.DataTypes
{
    public interface IModsEx
    {
        bool ShowShortMod { get; }
        Mods Mods { get; }

        /// <summary>
        /// Mods value shown to user
        /// </summary>
        string ShownMods { get; }

        /// <summary>
        /// Mods used for processing (eg. pp calculation)
        /// </summary>
        string WorkingMods { get; }

        bool Equals(object obj);
        int GetHashCode();
    }
}