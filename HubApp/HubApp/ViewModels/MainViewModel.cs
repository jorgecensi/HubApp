using System.Threading.Tasks;

namespace HubApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
       

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }


        public MainViewModel()
        {
            Descricao = "Ola mundo";
            Task.Delay(3000).ContinueWith(async t =>
            {
                Descricao = "O texto Mudou";
                for (int i = 1; i <= 10; i++)
                {
                    await Task.Delay(1000);
                    Descricao = $"O texto Mudou {i}";

                }

            });
        }

        
    }
}
