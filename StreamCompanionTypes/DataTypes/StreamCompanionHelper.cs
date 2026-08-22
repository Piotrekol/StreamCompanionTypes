using System.Drawing;
using System.Runtime.Versioning;

namespace StreamCompanionTypes.DataTypes
{
    [SupportedOSPlatform("windows")]
    public static class StreamCompanionHelper
    {
        public static Bitmap StreamCompanionLogo()
        {
            return new Bitmap(
                System.Reflection.Assembly.GetEntryAssembly().
                    GetManifestResourceStream("osu_StreamCompanion.Resources.logo_256x256.png"));
        }
    }
}