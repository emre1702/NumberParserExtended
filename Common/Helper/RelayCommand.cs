using System;
using System.Windows.Input;

namespace NumberParserExtended.Common.Helper
{
    // We won't need a generic RelayCommand for this project.
    // But in my previous projects I always needed it.
    // It's better to have it now than having to change it for later.
    public class RelayCommand<T> : ICommand
    {

        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        public RelayCommand(Action<T> execute) : this(execute, null) { }
         
        public RelayCommand(Action<T> execute, Func<T, bool>? canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
            => _canExecute?.Invoke((T)parameter) != false;

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
