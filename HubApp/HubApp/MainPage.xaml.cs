using HubApp.Models;
using HubApp.Services;
using HubApp.ViewModels;
using Xamarin.Forms;

namespace HubApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(new HubApiService());
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var tag = (sender as ListView)?.SelectedItem as Tag;
            (BindingContext as MainViewModel)?.ShowCategoriaCommand.Execute(tag);

        }
    }
}
