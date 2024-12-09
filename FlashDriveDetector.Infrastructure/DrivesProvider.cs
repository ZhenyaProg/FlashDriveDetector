using FlashDriveDetector.Core.Infrastructure;
using HotEject.Core;
using System;
using System.IO;
using System.Linq;

namespace FlashDriveDetector.Infrastructure
{
    public class DrivesProvider : IDrivesProvider
    {
        public event Action OnDrivesUpdated;

        public void Update()
        {
            OnDrivesUpdated?.Invoke();
        }

        public DriveInfo[] GetDrives()
        {
            var drivers = DriveInfo
                            .GetDrives()
                            .Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable)
                            .ToArray();

            return drivers;
        }

        public void Eject(string name)
        {
            DeviceManager.EjectVolumeDevice(name);
        }
    }
}