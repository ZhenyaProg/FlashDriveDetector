using FlashDriveDetector.Drivers;
using Core;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;

namespace FlashDriveDetector.Forms
{
    public class BackgroundForm : BaseForm
    {
        private readonly NotifyIcon _trayIcon;
        private readonly ContextMenu _trayMenu;
        private readonly IDriversController _drivesController;

        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_ENDSESSION = 0x0016;
        public const uint SHUTDOWN_NORETRY = 0x00000001;

        #region DllImports
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);

        [DllImport("kernel32.dll")]
        static extern bool SetProcessShutdownParameters(uint dwLevel, uint dwFlags);
        #endregion

        public BackgroundForm(IDriversController driversController)
        {
            SetProcessShutdownParameters(0xFF, SHUTDOWN_NORETRY);

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

            _drivesController = driversController;
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            SwitchTo<DrivesForm>();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            Opacity = 0;
            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            if (_drivesController.ContainsDrives)
            {
                DialogResult result = MessageBox.Show(this, 
                                                      "Есть активные флешки, хотите их посмотреть?", 
                                                      "ПРЕДУПРЕЖДЕНИЕ", 
                                                      MessageBoxButtons.YesNoCancel, 
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    SwitchTo<DrivesForm>();
                else if(result == DialogResult.No)
                {
                    Dispose(true);
                    Application.Exit();
                }
            }
            else
            {
                Dispose(true);
                Application.Exit();
            }
        }

        protected override void WndProc(ref Message m)
        {
            var drives = _drivesController.GetDrives();
            if ((m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION) &&
                 drives.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder($"Система не может быть выключена - есть {drives.Length} активных флешек:\r\n");
                foreach(var drive in drives)
                {
                    stringBuilder.AppendLine($"\t{drive.VolumeLabel} ({drive.Name}) {Math.Round(drive.TotalSize*Math.Pow(10, -9), 2)}GB");
                }
                ShutdownBlockReasonCreate(Handle, stringBuilder.ToString());
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