﻿namespace StreamCompanionTypes.Interfaces
{
    public interface ISaver
    {
        string SaveDirectory { get; set; }
        void Save(string directory, string content);
        void append(string directory, string content);
    }
}
