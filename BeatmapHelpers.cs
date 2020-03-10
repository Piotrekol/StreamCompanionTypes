using System.IO;
using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Interfaces;
using StreamCompanionTypes.Interfaces.Services;

namespace StreamCompanionTypes
{
    public static class BeatmapHelpers
    {
        public static string BeatmapDirectory(this IBeatmap beatmap, string songsDirectory)
        {
            return Path.Combine(songsDirectory, beatmap.Dir);
        }
        public static string FullOsuFileLocation(this IBeatmap beatmap, string songsDirectory)
        {
            var beatmapDirectory = beatmap.BeatmapDirectory(songsDirectory);
            if (string.IsNullOrEmpty(beatmapDirectory) || string.IsNullOrEmpty(beatmap.OsuFileName))
                return "";
            return Path.Combine(beatmapDirectory, beatmap.OsuFileName);
        }
        private static readonly SettingNames _names = SettingNames.Instance;

        public static string GetFullSongsLocation(ISettings settings)
        {
            var dir = settings.Get<string>(_names.SongsFolderLocation);
            if (dir == _names.SongsFolderLocation.Default<string>())
            {
                dir = settings.Get<string>(_names.MainOsuDirectory);
                dir = Path.Combine(dir, "Songs\\");
            }
            return dir;
        }

        public static string FullOsuFileLocation(this IBeatmap beatmap, ISettings settings)
        {
            return beatmap.FullOsuFileLocation(GetFullSongsLocation(settings));
        }

        public static bool IsValidBeatmap(this IBeatmap beatmap, ISettings settings, out string fullFileLocation)
        {
            fullFileLocation = beatmap.FullOsuFileLocation(settings);

            if (!File.Exists(fullFileLocation)) return false;
            FileInfo file = new FileInfo(fullFileLocation);

            return file.Length != 0;
        }
    }
}