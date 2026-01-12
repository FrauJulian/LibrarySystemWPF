using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using System.Windows.Input;
using LibrarySystemWPF.MainView.Controller;
using LibrarySystemWPF.MainView.ViewModels;

namespace LibrarySystemWPF.MainView.Commands;

public class SyncCommand(MainViewModel viewModel, MainController controller) : ICommand
{
    private DateTime _nextAllowed = DateTime.MinValue;
    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        var isReload = parameter as bool? ?? true;
        
        try
        {
            _nextAllowed = DateTime.UtcNow.AddSeconds(5);
            RaiseCanExecuteChanged();

            controller.LoadData(viewModel);

            if (isReload) 
                MessageBox.Show("Alle Daten wurden synchronisiert!");

            await Task.Delay(5000);
            RaiseCanExecuteChanged();
        }
        catch (Exception error)
        {
            MessageBox.Show(error.Message);
        }
    }
    
    private void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? CanExecuteChanged;
}