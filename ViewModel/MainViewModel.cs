using System.IO;
using System.Linq;
using System.Windows;
using NumberParserExtended.Common.Helper;
using NumberParserExtended.Common.Interfaces;

namespace NumberParserExtended.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public string NumbersFilePath 
        { 
            get => _numbersFilePath; 
            set
            {
                _numbersFilePath = value;
                RaisePropertyChanged();
            }
        }

        public string NumbersMappingFilePath
        {
            get => _numbersMappingFilePath;
            set
            {
                _numbersMappingFilePath = value;
                RaisePropertyChanged();
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<object?> ShowNumbersFileFolderDialogCommand { get; }
        public RelayCommand<object?> ShowNumbersMappingFileFolderDialogCommand { get; }
        public RelayCommand<object?> StartParsingCommand { get; }

        private string _numbersFilePath = string.Empty;
        private string _numbersMappingFilePath = string.Empty;
        private string _result = string.Empty;

        private IFileDialogHelper _fileDialogHelper;
        private IMappingGetter _mappingGetter;
        private IParsingHelper _parsingHelper;
        private ITabConverterHelper _tabConverterHelper;

        public MainViewModel(
            IFileDialogHelper fileDialogHelper,
            IMappingGetter mappingGetter,
            IParsingHelper parsingHelper,
            ITabConverterHelper tabConverterHelper)
        {
            _fileDialogHelper = fileDialogHelper;
            _mappingGetter = mappingGetter;
            _parsingHelper = parsingHelper;
            _tabConverterHelper = tabConverterHelper;

            ShowNumbersFileFolderDialogCommand = new RelayCommand<object?>(ShowNumbersFileFolderDialog);
            ShowNumbersMappingFileFolderDialogCommand = new RelayCommand<object?>(ShowNumbersMappingFileFolderDialog);
            StartParsingCommand = new RelayCommand<object?>(StartParsing, CanStartParsing);
        }

        private void ShowNumbersFileFolderDialog(object? arg)
        {
            string title = "Please select the file with the numbers to be parsed.";
            string? result = _fileDialogHelper.ShowDialog(title);
            if (result is { })
                NumbersFilePath = result;
        }

        private void ShowNumbersMappingFileFolderDialog(object? arg)
        {
            string title = "Please select the file with the mapping for the numbers.";
            string? result = _fileDialogHelper.ShowDialog(title);
            if (result is { })
                NumbersMappingFilePath = result;

        }

        /// <summary>
        /// Starts the parsing of the numbers file.
        /// </summary>
        /// <param name="arg">Not used</param>
        private void StartParsing(object? _)
        {
            // This is just a security measure if something wrong happened and WPF didn't know about a change for CanStartParsing. 
            if (!CanStartParsing(null))
            {
                RaisePropertyChanged(nameof(NumbersFilePath));
                RaisePropertyChanged(nameof(NumbersMappingFilePath));
                return;
            }
            
            // Need the mappings for the numbers to be able to detect them
            var mappings = _mappingGetter.GetMappings(NumbersMappingFilePath);
            if (mappings is null)
            {
                Result = string.Empty;
                return;
            }

            string[] lines = File.ReadAllLines(NumbersFilePath);

            #region Tab workaround
            // Tabs are a problem and can totally change the positions of the numbers
            // So we need to convert these tabs to spaces
            foreach (var mapping in mappings)
            {
                if (mapping.Item2.Any(m => m.Contains('\t')))
                {
                    _tabConverterHelper.ConvertToSpaces(mapping.Item2);
                }
            }
                
            if (lines.Any(l => l.Contains('\t')))
                _tabConverterHelper.ConvertToSpaces(lines);
            #endregion Tab workaround

            Result = _parsingHelper.Parse(lines, mappings);
        }

        /// <summary>
        /// Returns if we can start parsing.
        /// </summary>
        /// <param name="arg">Not used</param>
        /// <returns></returns>
        private bool CanStartParsing(object? _)
            => File.Exists(NumbersFilePath) && File.Exists(NumbersMappingFilePath);
    }
}
