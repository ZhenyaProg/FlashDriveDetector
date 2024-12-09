using System;
using System.Runtime.InteropServices;

namespace FlashDriveDetector.Core
{
    public class Imports
    {
        public const uint SHUTDOWN_NORETRY = 0x00000001;
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_ENDSESSION = 0x0016;
        public const int MOUNT_OR_EJECT = 537;

        //TODO: возможно стоит вынести в Infrastructure
        [DllImport("kernel32.dll")]
        public static extern bool SetProcessShutdownParameters(uint dwLevel, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);
    }
}