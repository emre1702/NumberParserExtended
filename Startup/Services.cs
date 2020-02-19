using Microsoft.Extensions.DependencyInjection;
using NumberParserExtended.Common.Helper;
using NumberParserExtended.Common.Interfaces;
using NumberParserExtended.View;
using NumberParserExtended.ViewModel;

namespace NumberParserExtended.Startup
{
    class Services
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            services
                // The main window
                .AddSingleton<IMainWindow, MainWindow>()    

                // Helper class to show a file browser dialog
                .AddSingleton<IFileDialogHelper, FileDialogHelper>()

                // Getter for the mapping
                // Currently XML format is used for the mapping
                // But you can also put it into e.g. JSON, SQL etc. and create another MappingGetter
                .AddSingleton<IMappingGetter, XMLMappingGetter>()

                // Inform the user about errors (and maybe more for the future?)
                .AddSingleton<IUserInformer, UserMessageBoxInformer>()

                // Helper class for parsing the numbers file
                .AddSingleton<IParsingHelper, ParsingHelper>()

                // Helper class to convert tabs to spaces
                .AddSingleton<ITabConverterHelper, TabConverterHelper>()

                // Main view model
                .AddTransient<IMainViewModel, MainViewModel>();

        }
    }
}
