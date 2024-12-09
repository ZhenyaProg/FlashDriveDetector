using System;
using System.Windows.Forms;
using FlashDriveDetector.Core;
//using Microsoft.Extensions.DependencyInjection;

namespace FlashDriveDetector
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Imports.SetProcessShutdownParameters(0x3FF, Imports.SHUTDOWN_NORETRY);
            //ServiceCollection serviceDescriptors = new ServiceCollection();
            //var provider = serviceDescriptors.BuildServiceProvider();
            //using (var test = provider.CreateScope())
            //{
            //}
            Application.Run(new AppContext());
        }
    }
}