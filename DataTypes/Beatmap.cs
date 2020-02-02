using CollectionManager.DataTypes;

namespace StreamCompanionTypes.DataTypes
{
    public class Beatmap : CollectionManager.DataTypes.Beatmap, IBeatmap
    {
        public new PlayModeStars ModPpStars
        {
            get => base.ModPpStars;
            set => base.ModPpStars = value;
        }
    }
}
