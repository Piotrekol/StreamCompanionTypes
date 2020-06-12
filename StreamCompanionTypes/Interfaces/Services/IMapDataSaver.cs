using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces.Services
{
    public interface IMapDataSaver
    {
        void StartMassStoring();
        void EndMassStoring();
        void StoreBeatmap(IBeatmap beatmap);

    }
}