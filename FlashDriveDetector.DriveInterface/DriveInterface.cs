﻿using HotEject.Core;
using System.IO;
using System.Linq;

namespace FlashDriveDetector.Drive
{
    public class DriveInterface : IDriveInterface
    {
        public int DriversCount => GetDrives().Length;

        public bool ContainsDrives => GetDrives().Any();

        public void EjectDrive(string driveLabel)
        {
            DeviceManager.EjectVolumeDevice(driveLabel);
        }

        public DriveInfo[] GetDrives()
        {
            var drivers = DriveInfo
                            .GetDrives()
                            .Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable)
                            .ToArray();

            return drivers;
        }
    }
}