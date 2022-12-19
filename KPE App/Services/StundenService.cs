using CommunityToolkit.Mvvm.ComponentModel;
using KPE_App.Objects;
using System;
using System.Net.Http.Json;
using System.Text.Json;

namespace KPE_App.Services
{
    public class StundenService : ObservableObject
    {
        #region Properties
        readonly HttpClient httpClient;

        static readonly string _FileName = "stundendata.json";
        readonly string _TargetPath = Path.Combine(FileSystem.Current.AppDataDirectory, _FileName);

        #endregion



        public StundenService()
        {
            this.httpClient = new HttpClient();
        }
        List<StundenEintragObj> stundenList;
         
        public List<StundenEintragObj> ViewStunden()
        {
            try
            {
                //if (Preferences.Get("OnlineMode", false))
                //{
                //    return stundenList;
                //}
                if (File.Exists(this._TargetPath))
                {
                    using FileStream streamlocal = File.OpenRead(_TargetPath);
                    return JsonSerializer.Deserialize<List<StundenEintragObj>>(streamlocal);
                }

                using FileStream stream = File.OpenRead("leer.json");
                return JsonSerializer.Deserialize<List<StundenEintragObj>>(stream);
            }

            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
                return null;
            }
            

        }

        public async Task<List<StundenEintragObj>> GetStunden()
        {

            if (Preferences.Get("OnlineMode", false))
            {
                var response = await httpClient.GetAsync("https://kpe-dev2.github.io/KPE-App/stundendata.json");
                //var response = await httpClient.GetAsync("https://kpe-automation.de/wp-content/uploads/stundendata.json");
                //var response = await httpClient.GetAsync("https://raw.githubusercontent.com/kpe-dev2/KPE-App/master/stundendata.json"); 

                if (response.IsSuccessStatusCode)
                {
                    stundenList = await response.Content.ReadFromJsonAsync<List<StundenEintragObj>>();

                    //Geladene Daten lokal abspeichern
                    using FileStream outputStreamOnline = File.Create(_TargetPath);
                    await JsonSerializer.SerializeAsync(outputStreamOnline, stundenList);
                    await outputStreamOnline.DisposeAsync();

                    //await streamWriter.WriteAsync(stundenList);
                }
                return stundenList;
            }

            using var stream = await FileSystem.OpenAppPackageFileAsync(_FileName);
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();

            using FileStream outputStream = File.Create(_TargetPath);
            await JsonSerializer.SerializeAsync(outputStream, stundenList);
            await outputStream.DisposeAsync();

            return JsonSerializer.Deserialize<List<StundenEintragObj>>(contents);
        }

        public async Task SaveStunden(List<StundenEintragObj> stunden)
        {
            using FileStream createStream = File.Create(_TargetPath);
            await JsonSerializer.SerializeAsync(createStream, stunden);
            await createStream.DisposeAsync();
        }


    }
}
