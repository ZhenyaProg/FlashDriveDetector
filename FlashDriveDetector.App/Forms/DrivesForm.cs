using Core;
using System;
using FlashDriveDetector.Drive;
using System.Windows.Forms;

namespace FlashDriveDetector.Forms
{
    public partial class DrivesForm : BaseForm
    {
        private readonly IDriveInterface _driversController;

        public DrivesForm(IDriveInterface driversController)
        {
            InitializeComponent();
            _driversController = driversController;
        }

        private void DrivesForm_Activated(object sender, EventArgs e)
        {
            _driversController.DrivesUpdated += UpdateDriveList;

            UpdateDriveList();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            _driversController.DrivesUpdated -= UpdateDriveList;

            SwitchTo<BackgroundForm>();
        }

        private void cmdEject_Click(object sender, EventArgs e)
        {
            var drives = _driversController.GetDrives();
            var driveName = drives[drivesList.SelectedIndex].Name;
            var useableName = driveName.Substring(0, driveName.IndexOf(':') + 1);
            _driversController.EjectDrive(useableName);

            MessageBox.Show($"Диск {useableName} был успешно извлечен", "УСПЕХ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateDriveList()
        {
            drivesList.Items.Clear();
            var drives = _driversController.GetDrives();
            foreach (var drive in drives)
            {
                drivesList.Items.Add($"{drive.VolumeLabel} ({drive.Name}) {Math.Round(drive.TotalSize * Math.Pow(10, -9), 2)}GB");
            }
            drivesList.SelectedIndex = drives.Length > 0 ? 0 : -1;
            cmdEject.Enabled = drives.Length > 0;
        }
    }
}