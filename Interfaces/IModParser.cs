using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces
{
     public interface IModParser
     {
         IModsEx GetModsFromEnum(int modsEnum);
         string GetModsFromEnum(int modsEnum, bool shortMod = false);
     }
}
