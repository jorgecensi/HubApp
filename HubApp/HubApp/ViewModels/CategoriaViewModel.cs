using HubApp.Models;
using HubApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HubApp.ViewModels
{
    public class CategoriaViewModel: BaseViewModel
    {
        private readonly IHubApiService _hubApiService;
        private readonly Tag _tag;

        public ObservableCollection<Content> Contents { get; }
        public Command<Content> ShowContentCommand { get; }

        public CategoriaViewModel(IHubApiService hubApiService, Tag tag)
        {
            _hubApiService = hubApiService;
            _tag = tag;

            Contents = new ObservableCollection<Content>();
            ShowContentCommand = new Command<Content>(ExecuteShowContentCommand);

        }

        private async void ExecuteShowContentCommand(Content content)
        {
            await PushAsync<ContentWebViewModel>(content);
        }

        public async Task LoadAsync()
        {
            var contents = await _hubApiService.GetContentsByTagIdAsync(_tag.Id);

            Contents.Clear();
            foreach(var content in contents)
            {
                Contents.Add(content);
            }
        }
    }
}
