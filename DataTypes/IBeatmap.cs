using System;
using CollectionManager.DataTypes;
using CollectionManager.Enums;

namespace StreamCompanionTypes.DataTypes
{
    public interface IBeatmap
    {
        double Stars(PlayMode playMode, Mods mods);
        void CloneValues(CollectionManager.DataTypes.Beatmap b);
        void InitEmptyValues();
        object Clone();
        string GetChecksum();
        int GetHashCode();
        bool Equals(object obj);
        string ToString();
        string ToString(bool withDiff);
        string TitleUnicode { get; set; }
        string ArtistUnicode { get; set; }
        string TitleRoman { get; set; }
        string ArtistRoman { get; set; }
        string Artist { get; }
        string Title { get; }
        string Creator { get; set; }
        string DiffName { get; set; }
        string Mp3Name { get; set; }
        string Md5 { get; set; }
        string OsuFileName { get; set; }
        string MapLink { get; }
        string MapSetLink { get; }
        double StarsNomod { get; }
        double MaxBpm { get; set; }
        double MinBpm { get; set; }
        double MainBpm { get; set; }
        string Tags { get; set; }
        string StateStr { get; }
        byte State { get; set; }
        short Circles { get; set; }
        short Sliders { get; set; }
        short Spinners { get; set; }
        DateTime? EditDate { get; set; }
        float ApproachRate { get; set; }
        float CircleSize { get; set; }
        float HpDrainRate { get; set; }
        float OverallDifficulty { get; set; }
        double SliderVelocity { get; set; }
        int DrainingTime { get; set; }
        int TotalTime { get; set; }
        int PreviewTime { get; set; }
        int MapId { get; set; }
        int MapSetId { get; set; }
        int ThreadId { get; set; }
        OsuGrade OsuGrade { get; set; }
        OsuGrade TaikoGrade { get; set; }
        OsuGrade CatchGrade { get; set; }
        OsuGrade ManiaGrade { get; set; }
        short Offset { get; set; }
        float StackLeniency { get; set; }
        PlayMode PlayMode { get; set; }
        string Source { get; set; }
        short AudioOffset { get; set; }
        string LetterBox { get; set; }
        bool Played { get; set; }
        DateTime? LastPlayed { get; set; }
        bool IsOsz2 { get; set; }
        string Dir { get; set; }
        DateTime? LastSync { get; set; }
        bool DisableHitsounds { get; set; }
        bool DisableSkin { get; set; }
        bool DisableSb { get; set; }
        short BgDim { get; set; }
        int Somestuff { get; set; }
        PlayModeStars ModPpStars { get; set; }

    }
}