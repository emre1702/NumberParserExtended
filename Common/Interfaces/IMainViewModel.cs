using NumberParserExtended.Common.Helper;

namespace NumberParserExtended.Common.Interfaces
{
    public interface IMainViewModel
    {
        string NumbersFilePath { get; set; }
        string NumbersMappingFilePath { get; set; }
        string Result { get; set; }

        RelayCommand<object?> ShowNumbersFileFolderDialogCommand { get; }
        RelayCommand<object?> ShowNumbersMappingFileFolderDialogCommand { get; }
        RelayCommand<object?> StartParsingCommand { get; }
    }
}
