using FlashDriveDetector.Drivers;
using Core;
using System;

namespace FlashDriveDetector.Forms
{
    public partial class DrivesForm : BaseForm
    {
        private readonly IDriversController _driversController;

        public DrivesForm(IDriversController driversController)
        {
            InitializeComponent();
            _driversController = driversController;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            SwitchTo<BackgroundForm>();
        }

        private void DrivesForm_Activated(object sender, EventArgs e)
        {
            drivesList.Items.Clear();
            var drives = _driversController.GetDrives(); 
            foreach (var drive in drives)
            {
                drivesList.Items.Add($"{drive.VolumeLabel} ({drive.Name}) {Math.Round(drive.TotalSize * Math.Pow(10, -9), 2)}GB");
            }
        }
    }
}