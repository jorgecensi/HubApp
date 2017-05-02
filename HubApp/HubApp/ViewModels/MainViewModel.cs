using System.Collections.ObjectModel;
using Xamarin.Forms;

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
        public ObservableCollection<string> Resultados { get; }

        public Command SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand,CanExecuteSearchCommand);

            Resultados = new ObservableCollection<string>(new []{ "abc", "cde" });
        }

        async void ExecuteSearchCommand()
        {
            // não é recomendável deixar o código abaixo, é somente para estudos
            await App.Current.MainPage.DisplayAlert("HubApp", "mensagem", "OK");
            Resultados.Add("ItenLIsta");
        }

        bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }
    }
}
