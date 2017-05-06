using HubApp.Models;
using HubApp.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace HubApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {

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

        public Command AboutCommand { get; }

        public Command<Tag> ShowCategoriaCommand { get; }

        //readonly por precaução para não poder alterar a instancia fora do construtor
        private readonly IHubApiService _hubApiService;

        public MainViewModel(IHubApiService hubApiService)
        {
            _hubApiService = hubApiService;

            SearchCommand = new Command(ExecuteSearchCommand,CanExecuteSearchCommand);

            Resultados = new ObservableCollection<Tag>();

            AboutCommand = new Command(ExecuteAboutCommand);

            ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);
        }

        private async void ExecuteShowCategoriaCommand(Tag tag)
        {
            await PushAsync<CategoriaViewModel>(_hubApiService, tag);
        }

        async void ExecuteAboutCommand()
        {
            await PushAsync<AboutViewModel>();
        }

        async void ExecuteSearchCommand()
        {
            // não é recomendável deixar o código abaixo, é somente para estudos
            await App.Current.MainPage.DisplayAlert("HubApp", "mensagem", "OK");
            var tagsRetornadasDoServico = await _hubApiService.GetTagsAsync();

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
