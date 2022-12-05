using KPE_App.Objects;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace KPE_App.Services
{
    public class StundenService
    {

        HttpClient httpClient;
        public StundenService()
        {
            this.httpClient = new HttpClient();
        }
        List<StundenEintragObj> stundenList;
        public async Task<List<StundenEintragObj>> GetStunden()
        {
            
            var response = await httpClient.GetAsync("https://api.jsonbin.io/v3/b/638de2eb8147d56a302eb137");
            
            //var response = await httpClient.GetAsync("https://www.gaer.is-best.net/upload/stundendata.json");
            if (response.IsSuccessStatusCode)
            {
                stundenList = await response.Content.ReadFromJsonAsync<List<StundenEintragObj>>();
            }
            return stundenList;


            //using var stream = await FileSystem.OpenAppPackageFileAsync("stundendata.json");
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            //return JsonSerializer.Deserialize<List<StundenEintragObj>>(contents);
        }

        public async Task UpdateStunden(List<StundenEintragObj> stunden)
        {
            await Task.Delay(1000);
        }
    }
}
