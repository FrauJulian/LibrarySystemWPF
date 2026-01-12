using System.Windows.Input;
using DbAccess.Access.Person;
using LibrarySystemWPF.MainView.ViewModels;

namespace LibrarySystemWPF.MainView.Commands;

internal class PersonSearchCommand(MainViewModel viewModel) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var searchString = parameter?.ToString() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(searchString))
        {
            viewModel.SyncCommand.Execute(false);
            return;
        }

        viewModel.Persons = viewModel.Persons
            .Where(person =>
                person.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || $"{person.FirstName} {person.LastName}".Contains(searchString,
                    StringComparison.CurrentCultureIgnoreCase))
            .ToList();
    }

    public event EventHandler? CanExecuteChanged;
}