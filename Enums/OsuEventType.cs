namespace StreamCompanionTypes.Enums
{
    public enum OsuEventType
    {
        MapChange,//When map changes
        MapStatusChange,//When user map status changes(eg. listening->watching, playing->listening)
        SceneChange,//When osu! ingame scene changes(eg. user goes from main menu to song selection)
    }
}