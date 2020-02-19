using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NumberParserExtended.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
