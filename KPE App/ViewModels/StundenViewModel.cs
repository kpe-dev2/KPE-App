using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KPE_App.Objects;
using KPE_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace KPE_App.ViewModels;

public partial class StundenViewModel : BaseViewModel
{

    private ObservableCollection<StundenEintragObj> _Stunden = new();
    public ObservableCollection<StundenEintragObj> Stunden
    {
        get { return _Stunden; }
        set { SetProperty(ref _Stunden, value); }
    }
    StundenService stundenService;



    public StundenViewModel(StundenService stundenService)
    {
        Title = "Übersicht";
        this.stundenService = stundenService;
    }

    [RelayCommand]
    async Task GetStundenAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Stunden = new(await stundenService.GetStunden());

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }




    //#region Ctor
    //public StundenViewModel()
    //{
    //    Title = "Übersicht";
    //}
    //#endregion

    //#region Properties
    //private ObservableCollection<StundenEintragObj> _Stunden = new();
    //public ObservableCollection<StundenEintragObj> Stunden
    //{
    //    get { return _Stunden; }
    //    set { SetProperty(ref _Stunden, value); }
    //}

    //#endregion

    #region Commands

    //[RelayCommand]
    //async Task GetStundenAsync()
    //{
    //    if (IsBusy)
    //        return;

    //    try
    //    {
    //        IsBusy = true;
    //        Stunden = new(await StundenService.GetStunden());
    //    }
    //    catch (Exception ex)
    //    {
    //        //Debug.WriteLine($"Unable to get hours: {ex.Message}");
    //        await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
    //    }
    //    finally
    //    {
    //        IsBusy = false;
    //    }
    //}

    [RelayCommand]
    async Task RemoveStundeAsync(StundenEintragObj stunde)
    {
        if (IsBusy)
            return;
        try
        {
            Stunden.Remove(stunde);
            //await Task.Delay(1000);
            await stundenService.UpdateStunden(Stunden.ToList());
        }
        catch (Exception)
        {

        }
        finally { IsBusy = false; }
    }
    #endregion

}

