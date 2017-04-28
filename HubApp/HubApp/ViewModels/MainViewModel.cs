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

        public Command SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand,CanExecuteSearchCommand);
        }

        async void ExecuteSearchCommand()
        {
            // não é recomendável deixar o código abaixo, é somente para estudos
            await App.Current.MainPage.DisplayAlert("HubApp", "mensagem", "OK");
        }

        bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }
    }
}
