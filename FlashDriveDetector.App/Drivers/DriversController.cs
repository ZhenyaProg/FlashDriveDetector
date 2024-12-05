using System.IO;
using System.Linq;

namespace FlashDriveDetector.Drivers
{
    public class DriversController : IDriversController
    {
        public int DriversCount => GetDrives().Length;

        public bool ContainsDrives => GetDrives().Any();

        public DriveInfo[] GetDrives()
        {
            var drivers = DriveInfo.GetDrives()
                       .Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable)
                       .ToArray();

            return drivers;
        }
    }
}