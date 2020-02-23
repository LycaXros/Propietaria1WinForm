using System;

namespace Client.Events
{
    public class SaveDataArgs : EventArgs
    {
        public bool IsEditing { get; }
        public SaveDataArgs(bool isEditing)
        {
            IsEditing = isEditing;
        }
    }
}
