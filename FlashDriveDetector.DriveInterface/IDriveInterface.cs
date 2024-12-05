using System.IO;

namespace FlashDriveDetector.Drive
{
    public interface IDriveInterface
    {
        int DriversCount { get; }
        bool ContainsDrives { get; }

        void EjectDrive(string driveName);
        DriveInfo[] GetDrives();
    }
}