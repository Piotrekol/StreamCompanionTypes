namespace StreamCompanionTypes.Enums
{
    public enum OsuEventType
    {
        /// <summary>
        /// When map changes
        /// </summary>
        MapChange,
        /// <summary>
        /// When osu! ingame scene changes(eg. listening->watching, playing->listening, listening->resultsScreen)
        /// </summary>
        SceneChange,
        /// <summary>
        /// When new play is started in osu(user retries a map)
        /// </summary>
        PlayChange,
    }
}