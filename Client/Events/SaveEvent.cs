using System;

namespace Client.Events
{
    public class SaveDataArgs : EventArgs
    {
        public bool IsEditing { get; }
        public bool SaveData { get; }
        public SaveDataArgs(bool isEditing)
        {
            IsEditing = isEditing;
            SaveData = false;
        }
        public SaveDataArgs(bool isEditing, bool saveData)
        {
            IsEditing = isEditing;
            SaveData = saveData;
        }
    }
}
