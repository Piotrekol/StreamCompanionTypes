using System;
using System.Collections.Generic;
using CollectionManager.DataTypes;

namespace StreamCompanionTypes.DataTypes
{
    public class ModsEx : IEquatable<ModsEx>, IModsEx
    {
        public bool ShowShortMod { get; }
        public Mods Mods { get; }
        private string _shortMods;
        private string _filteredShortMods;

        private string ShortMods
        {
            get => _shortMods;
            set
            {
                _shortMods = value;
                _filteredShortMods = value
                    .Replace("AU", "")
                    .Replace("AP", "")
                    .Replace("SV2", "")
                    .Replace("RL", "")
                    .Replace("CO", "DS") //Coop is named Dual Stages in osu!lazer
                    .Replace("TD", ""); //ppy/osu#4441
            }
        }
        private readonly string LongMods;
        /// <summary>
        /// Mods value shown to user
        /// </summary>
        public string ShownMods => ShowShortMod ? ShortMods : LongMods;

        /// <summary>
        /// Mods used for processing (eg. pp calculation)
        /// </summary>
        public string WorkingMods => Mods == Mods.Omod ? "" : _filteredShortMods;

        public ModsEx(bool showShortMod, Mods mods, string shortMods, string longMods)
        {
            ShowShortMod = showShortMod;
            ShortMods = shortMods;
            LongMods = longMods;
            Mods = mods;
        }

        public bool Equals(ModsEx other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _shortMods == other._shortMods && _filteredShortMods == other._filteredShortMods && LongMods == other.LongMods && ShowShortMod == other.ShowShortMod && Mods == other.Mods;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ModsEx) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_shortMods != null ? _shortMods.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_filteredShortMods != null ? _filteredShortMods.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LongMods != null ? LongMods.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ShowShortMod.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Mods;
                return hashCode;
            }
        }
    }
}