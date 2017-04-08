using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ImgAlgs.ViewModels
{
    /// <summary>
    /// Базовый класс для ViewModel
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие "Изменение значения свойства"
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Выполняет оповещение об изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Наименование свойства</param>
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
