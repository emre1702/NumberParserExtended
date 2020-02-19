using MahApps.Metro.Controls;
using NumberParserExtended.Common.Interfaces;

namespace NumberParserExtended.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, IMainWindow
    {
        public MainWindow(IMainViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
