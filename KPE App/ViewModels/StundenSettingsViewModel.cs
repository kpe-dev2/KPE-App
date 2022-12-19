using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPE_App.ViewModels
{
    public class StundenSettingsViewModel : ObservableObject
    {
        #region Ctor
        public StundenSettingsViewModel()
        {
            OnlineMode = Preferences.Get("OnlineMode", false);
        }
        #endregion

        #region Properties

        private bool _OnlineMode;
        public bool OnlineMode
        {
            get { return _OnlineMode; }
            set
            {
                SetProperty(ref _OnlineMode, value);
                Preferences.Set("OnlineMode", value);
            }
        }

        #endregion
    }
}
