using System.IO;

namespace FlashDriveDetector.Drivers
{
    public interface IDriversController
    {
        int DriversCount { get; }
        bool ContainsDrives { get; }

        DriveInfo[] GetDrives();
    }
}