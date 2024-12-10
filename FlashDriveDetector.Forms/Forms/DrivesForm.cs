using Core;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using FlashDriveDetector.Core.Infrastructure;
using FlashDriveDetector.Core.UseCases;

namespace FlashDriveDetector.Forms
{
    public partial class DrivesForm : BaseForm
    {
        private readonly IDrivesProvider _drivesProvides;
        private readonly IServiceProvider _serviceProvider;

        public DrivesForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _drivesProvides = serviceProvider.GetRequiredService<IDrivesProvider>();
            _serviceProvider = serviceProvider;
        }

        private void DrivesForm_Activated(object sender, EventArgs e)
        {
            UpdateDriveList();
            _drivesProvides.OnDrivesUpdated += UpdateDriveList;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            _drivesProvides.OnDrivesUpdated -= UpdateDriveList;
            SwitchTo<BackgroundForm>();
        }

        private void cmdEject_Click(object sender, EventArgs e)
        {
            var useCase = _serviceProvider.GetRequiredService<IEjectDriveUseCase>();
            var driveName = useCase.Execute(drivesList.SelectedIndex);
            MessageBox.Show($"Диск {driveName} был успешно извлечен", "УСПЕХ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateDriveList()
        {
            var useCase = _serviceProvider.GetRequiredService<IGetDrivesUseCase>();
            var drives = useCase.Execute();
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