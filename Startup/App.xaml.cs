using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using NumberParserExtended.Common.Interfaces;

namespace NumberParserExtended.Startup
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            // Add Dependency Injection
            var serviceCollection = new ServiceCollection();

            Services.ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetService<IMainWindow>();
            mainWindow.Show();
        }
    }
}
