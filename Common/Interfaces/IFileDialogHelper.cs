using System;
using System.Collections.Generic;
using System.Text;

namespace NumberParserExtended.Common.Interfaces
{
    public interface IFileDialogHelper
    {
        /// <summary>
        /// Shows the file browser dialog and returns the path of the file.
        /// </summary>
        /// <param name="title">Title to show in the dialog.</param>
        /// <returns>Path of the file</returns>
        string? ShowDialog(string title);
    }
}
