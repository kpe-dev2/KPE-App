using CommunityToolkit.Mvvm.Input;
using KPE_App.Objects;
using KPE_App.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace KPE_App.ViewModels;

public partial class StundenViewModel : BaseViewModel
{
    #region Ctor

    public StundenViewModel(StundenService stundenService)
    {
        Title = "Übersicht";
        this.stundenService = stundenService;
        ViewStunden();
    }
    #endregion

    #region Properties

    readonly StundenService stundenService;

    private ObservableCollection<StundenEintragObj> _Stunden = new();
    public ObservableCollection<StundenEintragObj> Stunden
    {
        get { return _Stunden; }
        set { SetProperty(ref _Stunden, value); }
    }

    private PermissionStatus _Write;
    public PermissionStatus Write
    {
        get { return _Write; }
        set { SetProperty(ref _Write, value); }
    }

    private string _Vorname;
    public string Vorname
    {
        get { return _Vorname; }
        set { SetProperty(ref _Vorname, value); }
    }

    private string _Nachname;
    public string Nachname
    {
        get { return _Nachname; }
        set { SetProperty(ref _Nachname, value); }
    }

    private string _ProjektNummer;
    public string ProjektNummer
    {
        get { return _ProjektNummer; }
        set { SetProperty(ref _ProjektNummer, value); }
    }

    private string _FreiText;
    public string FreiText
    {
        get { return _FreiText; }
        set { SetProperty(ref _FreiText, value); }
    }

    private string _DateAnfang;
    public string DateAnfang
    {
        get { return _DateAnfang; }
        set { SetProperty(ref _DateAnfang, value); }
    }

    private string _TimeAnfang;
    public string TimeAnfang
    {
        get { return _TimeAnfang; }
        set { SetProperty(ref _TimeAnfang, value); }
    }

    private string _DateEnde;
    public string DateEnde
    {
        get { return _DateEnde; }
        set { SetProperty(ref _DateEnde, value); }
    }

    private string _TimeEnde;
    public string TimeEnde
    {
        get { return _TimeEnde; }
        set { SetProperty(ref _TimeEnde, value); }
    }

    private StundenEintragObj _NewEntry = new();
    public StundenEintragObj NewEntry
    {
        get { return _NewEntry; }
        set { SetProperty(ref _NewEntry, value); }
    }

    #endregion

    #region Commands

    [RelayCommand]
    void ViewStunden()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Stunden = new(stundenService.ViewStunden());

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get hours: {ex.Message}");
            Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

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
            Debug.WriteLine($"Unable to get hours: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }

    [RelayCommand]
    void AddStunde()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            if (string.IsNullOrWhiteSpace(NewEntry.Vorname) || string.IsNullOrWhiteSpace(NewEntry.Nachname) || string.IsNullOrWhiteSpace(NewEntry.ProjektNummer))
            {
                //Bitte vollständig eintragen bla bla bla
                return;
            }

            Stunden.Add(NewEntry);
            //NewEntry = new();
            Stunden = new(Stunden.OrderBy(x => x.AnfangDatum));

            //Message Erfolgreich eingetragen
        }
        catch (Exception ex)
        {
            Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally { IsBusy = false; }
    }

    [RelayCommand]
    void RemoveStunde(StundenEintragObj stunde)
    {
        if (IsBusy)
            return;
        try
        {
            Stunden.Remove(stunde);
        }
        catch (Exception ex)
        {
            Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally { IsBusy = false; }
    }
    [RelayCommand]
    async Task SaveStundenAsync()
    {
        if (IsBusy)
            return;
        try
        {
            var statusWrite = PermissionStatus.Unknown;
            statusWrite = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (Permissions.ShouldShowRationale<Permissions.StorageWrite>())
            {
                await Shell.Current.DisplayAlert("Schreib Berechtigung", "Schreibrechte werden für das Abspeichern der Daten benötigt.", "Ok");
            }
            if (statusWrite != PermissionStatus.Granted)
                statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();

            if (statusWrite == PermissionStatus.Granted)
                await stundenService.SaveStunden(Stunden.ToList());
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");

        }
        finally { IsBusy = false; }
    }
    #endregion

}

