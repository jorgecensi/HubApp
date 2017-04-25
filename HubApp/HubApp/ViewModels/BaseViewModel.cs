
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HubApp.ViewModels
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Este método irá invocar um evento de alteração de propriedade passando o nome da propriedade que chamou ela,
        /// utilizando o CallerMemberName.
        /// </summary>
        /// <param name="propertyName">nome da propriedade que chamou o metodo</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            /// O "PropertyChanged?" é utilizado no lugar de if(PropertyChanged != null)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Altera o valor do parametro passado por referencia pelo value somente se for diferente.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
