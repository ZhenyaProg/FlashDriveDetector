using Core;
using FlashDriveDetector.Core.Infrastructure;
using FlashDriveDetector.Core.UseCases;
using System;
using System.Windows.Forms;

namespace FlashDriveDetector.Forms
{
    public partial class DrivesForm : BaseForm
    {
        private readonly IEjectDriveUseCase _ejectDriveUseCase;
        private readonly IGetDrivesUseCase _getDrivesUseCase;
        private readonly IDrivesProvider _drivesProvider;

        public DrivesForm( //TODO: сюда контейнер зависимостей
            IEjectDriveUseCase ejectDriveUseCase,
            IGetDrivesUseCase getDrivesUseCase,
            IDrivesProvider drivesProvider)
        {
            InitializeComponent();

            _ejectDriveUseCase = ejectDriveUseCase;
            _getDrivesUseCase = getDrivesUseCase;
            _drivesProvider = drivesProvider;
        }

        private void DrivesForm_Activated(object sender, EventArgs e)
        {
            UpdateDriveList();
            _drivesProvider.OnDrivesUpdated += UpdateDriveList;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            _drivesProvider.OnDrivesUpdated -= UpdateDriveList;
            SwitchTo<BackgroundForm>();
        }

        private void cmdEject_Click(object sender, EventArgs e)
        {
            var driveName = _ejectDriveUseCase.Execute(drivesList.SelectedIndex);
            MessageBox.Show($"Диск {driveName} был успешно извлечен", "УСПЕХ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateDriveList()
        {
            var drives = _getDrivesUseCase.Execute();
            drivesList.Items.Clear();
            foreach (var drive in drives)
            {
                drivesList.Items.Add(drive);
            }
            drivesList.SelectedIndex = drives.Length > 0 ? 0 : -1;
            cmdEject.Enabled = drives.Length > 0;
        }
    }
}