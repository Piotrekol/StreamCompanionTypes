using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes
{
    public interface IOutputPattern
    {
        event PropertyChangedEventHandler PropertyChanged;
        ReadOnlyObservableCollection<string> MemoryFormatTokens { get; }
        Tokens Replacements { get; set; }
        string Name { get; set; }
        string Pattern { get; set; }
        string SaveEventStr { get; }
        bool ShowInOsu { get; set; }
        int XPosition { get; set; }
        int YPosition { get; set; }
        Color Color { get; set; }
        string FontName { get; set; }
        int FontSize { get; set; }
        int Aligment { get; set; }
        OsuStatus SaveEvent { get; set; }
        bool IsMemoryFormat { get; }
        object Clone();
        string GetFormatedPattern(OsuStatus status = OsuStatus.All);
    }
}