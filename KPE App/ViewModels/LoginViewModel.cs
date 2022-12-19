using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Net.Http.Json;

namespace KPE_App.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        #region Ctor
        public LoginViewModel()
        {
        }
        #endregion

        #region Properties
        readonly HttpClient httpClient = new();

        private string _EMail;
        public string EMail
        {
            get { return _EMail; }
            set { SetProperty(ref _EMail, value); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        private bool _EnableSubmitBtn;
        public bool EnableSubmitBtn
        {
            get { return _EnableSubmitBtn; }
            set { SetProperty(ref _EnableSubmitBtn, value); }
        }



        #endregion

        #region Commands
        [RelayCommand]
        async Task PushLoginInfo()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                //httpClient.BaseAddress = new Uri("https://kpeapi.azurewebsites.net/api/");
                var myObject = new
                {
                    eMail = EMail,
                    password = Password,
                };

                if (Password.Length<6)
                {
                    await Shell.Current.DisplayAlert("Error!","Bitte mehr als 6 Zeichen für das Passwort verwenden!", "OK");
                }

                if (!EMail.Contains('@'))
                {
                    await Shell.Current.DisplayAlert("Error!", "Bitte eine gültige E-Mail-Adresse verwenden!", "OK");
                }
         

                HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://kpeapi.azurewebsites.net/api/Auth/login", myObject);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    await SecureStorage.Default.SetAsync("oauth_token", token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to login!: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        [RelayCommand]
        async Task GetProjects()
        {
            if (IsBusy)
                return;

            try
            {
                string token = string.Empty;
                token = await SecureStorage.Default.GetAsync("oauth_token");
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = await httpClient.GetAsync("https://kpeapi.azurewebsites.net/api/Project/getprojects");
                if (response.IsSuccessStatusCode)
                {
                    var projects = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to login!: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GetTokenInfo()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                string oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

                if (oauthToken == null)
                {
                    // No value is associated with the key "oauth_token"
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to login!: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
