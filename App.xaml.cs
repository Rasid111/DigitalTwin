using DigitalTwin.ViewModels;
using DigitalTwin.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DigitalTwin;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Создаем ViewModel с SampleFactory
        var mainViewModel = new MainViewModel();

        // Создаем главное окно
        var mainWindow = new MainWindow
        {
            DataContext = mainViewModel
        };

        mainWindow.Show();
    }
}

