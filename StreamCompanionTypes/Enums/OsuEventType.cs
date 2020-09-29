namespace StreamCompanionTypes.Enums
{
    public enum OsuEventType
    {
        MapChange,//When map changes
        SceneChange,//When osu! ingame scene changes(eg. listening->watching, playing->listening)
        PlayChange,//When new play is started in osu(user retries a map)
    }
}