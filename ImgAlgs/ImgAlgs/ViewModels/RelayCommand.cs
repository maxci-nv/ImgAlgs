using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImgAlgs.ViewModels
{
    /// <summary>
    /// Класс команды
    /// </summary>
    class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _action;

        public RelayCommand(Action<object> action, Predicate<object> canExecute = null)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            _canExecute = canExecute;
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (_canExecute != null) ? _canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
