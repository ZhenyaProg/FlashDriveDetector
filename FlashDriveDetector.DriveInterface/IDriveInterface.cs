using System;
using System.IO;

namespace FlashDriveDetector.Drive
{
    public interface IDriveInterface
    {
        event Action DrivesUpdated;

        int DriversCount { get; }
        bool ContainsDrives { get; }

        void EjectDrive(string driveName);
        void Update();
        DriveInfo[] GetDrives();
    }
}