using System;
using System.IO;

namespace FlashDriveDetector.Core.Infrastructure
{
    public interface IDrivesProvider
    {
        event Action OnDrivesUpdated;

        void Update();
        void Eject(string useableName);
        DriveInfo[] GetDrives();
    }
}