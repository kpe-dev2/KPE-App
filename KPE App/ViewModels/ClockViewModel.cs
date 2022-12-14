using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IntelliJ.Lang.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPE_App.ViewModels

{
    public partial class ClockViewModel : BaseViewModel
    {

        #region Ctor
        public ClockViewModel()
        {
            this.DateTime = DateTime.Now;
            // Update the DateTime property every second.
            Timer = new Timer(new TimerCallback((s) => this.DateTime = DateTime.Now),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        #endregion


        #region Properties

        private DateTime _DateTime;
        public DateTime DateTime
        {
            get { return _DateTime; }
            set { SetProperty(ref _DateTime, value); }
        }

        private Timer _Timer;
        public Timer Timer
        {
            get { return _Timer; }
            set { SetProperty(ref _Timer, value); }
        }



        #endregion


        #region Commands
        #endregion
    }
}
