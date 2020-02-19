using NumberParserExtended.Common.Interfaces;
using Microsoft.Win32;

namespace NumberParserExtended.Common.Helper
{
    public class FileDialogHelper : IFileDialogHelper
    {
        public string? ShowDialog(string title)
        {
            var fileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = title
            };
            if (fileDialog.ShowDialog() == true)
            {
                var file = fileDialog.FileName;
                return file;
            }

            return null;
        }
    }
}
