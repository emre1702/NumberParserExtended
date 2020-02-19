using System.Windows;
using NumberParserExtended.Common.Interfaces;

namespace NumberParserExtended.Common.Helper
{
    public class UserMessageBoxInformer : IUserInformer
    {
        public void ShowError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
