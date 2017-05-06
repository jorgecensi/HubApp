using HubApp.Models;

namespace HubApp.ViewModels
{
    public class ContentWebViewModel:BaseViewModel
    {
        public Content Content { get; }

        public ContentWebViewModel(Content content)
        {
            Content = content;
        }
    }
}
