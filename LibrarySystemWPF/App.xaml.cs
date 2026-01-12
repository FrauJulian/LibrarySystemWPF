using System.Windows;
using DbAccess;
using LibrarySystemWPF.MainView.Controller;

namespace LibrarySystemWPF;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void ApplicationStartup(object sender, StartupEventArgs e)
    {
        try
        {
            var dbCore = new Core();
            var mainController = new MainController(dbCore);

            var mainView = mainController.Create();
            mainView.Show();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}