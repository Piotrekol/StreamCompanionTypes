using System.Drawing;

namespace StreamCompanionTypes.DataTypes
{
    public static class StreamCompanionHelper //Designer doesn't allow for this class to be abstract
    {
        public static Bitmap StreamCompanionLogo()
        {
            return new Bitmap(
                System.Reflection.Assembly.GetEntryAssembly().
                    GetManifestResourceStream("osu_StreamCompanion.Resources.logo_256x256.png"));
        }
    }
}