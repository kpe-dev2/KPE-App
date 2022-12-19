using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPE_App.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        #region Ctor
        public RegisterViewModel()
        {

        }
        #endregion

        #region Properties
        #endregion

        #region Commands
        //[RelayCommand]
        //async Task PushRegisterInfo()
        //{
        //    if (IsBusy)
        //        return;

        //    try
        //    {
        //        IsBusy = true;


        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Unable to register!: {ex.Message}");
        //        await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
        #endregion
    }
}
