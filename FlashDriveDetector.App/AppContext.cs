using FlashDriveDetector.Drivers;
using FlashDriveDetector.Forms;
using Core;
using Core.Input;
using System;

namespace FlashDriveDetector
{
    internal class AppContext : BaseAppContext
    {
        public AppContext() : base()
        {
        }

        protected override Type Form => typeof(BackgroundForm);

        protected override Func<InputController, BaseForm[]> FormsFactory => (inputController) =>
        {
            var driversController = new DriversController();

            return new BaseForm[]
            {
                new BackgroundForm(driversController),
                new DrivesForm(driversController),
            };
        };
    }
}