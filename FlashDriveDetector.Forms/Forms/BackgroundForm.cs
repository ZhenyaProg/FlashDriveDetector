using Core;
using System;
using System.Windows.Forms;
using FlashDriveDetector.Core.UseCases;
using FlashDriveDetector.Core.Models;
using FlashDriveDetector.Core;

namespace FlashDriveDetector.Forms
{
    public class BackgroundForm : BaseForm
    {
        private readonly NotifyIcon _trayIcon;
        private readonly ContextMenu _trayMenu;
        private readonly IExitUseCase _exitUseCase;
        private readonly IShutdownUseCase _shutdownUseCase;
        private readonly IUpdateDrivesUseCase _updateDrivesUseCase;

        public BackgroundForm(
            IExitUseCase exitUseCase,
            IShutdownUseCase shutdownUseCase,
            IUpdateDrivesUseCase mountOrEjectUseCase)
        {
            _trayMenu = new ContextMenu();
            _trayMenu.MenuItems.Add("Показать флешки", (o, e) => SwitchTo<DrivesForm>());
            _trayMenu.MenuItems.Add("Выход", OnExit);

            _trayIcon = new NotifyIcon()
            {
                Text = "Обнаружение флешек",
                Icon = Icon,
                ContextMenu = _trayMenu,
                Visible = true,
            };
            _trayIcon.MouseClick += OnClick;
            _exitUseCase = exitUseCase;
            _shutdownUseCase = shutdownUseCase;
            _updateDrivesUseCase = mountOrEjectUseCase;
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            SwitchTo<DrivesForm>();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            ShowInTaskbar = false;
            Opacity = 0;
            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            ExitState exitState = _exitUseCase.Execute();
            switch (exitState)
            {
                case ExitState.Exit:
                    Dispose(true);
                    Application.Exit();
                    break;
                case ExitState.ShowDrives:
                    SwitchTo<DrivesForm>();
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Imports.WM_QUERYENDSESSION || m.Msg == Imports.WM_ENDSESSION)
            {
                _shutdownUseCase.Execute(Handle);
            }
            else if(m.Msg == Imports.MOUNT_OR_EJECT)
            {
                _updateDrivesUseCase.Execute();
            }
            else
                base.WndProc(ref m);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _trayIcon.Dispose();
            }
            _trayIcon.MouseClick -= OnClick;
            base.Dispose(isDisposing);
        }
    }
}