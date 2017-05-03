using HubApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HubApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {

        private const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";

        public async Task<List<Tag>> GetTagsAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Tags").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Tag>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (SetProperty(ref _searchTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }
        public ObservableCollection<Tag> Resultados { get; }

        public Command SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand,CanExecuteSearchCommand);

            Resultados = new ObservableCollection<Tag>();
        }

        async void ExecuteSearchCommand()
        {
            // não é recomendável deixar o código abaixo, é somente para estudos
            await App.Current.MainPage.DisplayAlert("HubApp", "mensagem", "OK");
            var tagsRetornadasDoServico = await GetTagsAsync();

            if(tagsRetornadasDoServico != null)
            {
                foreach (var tag in tagsRetornadasDoServico)
                {
                    Resultados.Add(tag);
                }
            }

            
        }

        bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }
    }
}
