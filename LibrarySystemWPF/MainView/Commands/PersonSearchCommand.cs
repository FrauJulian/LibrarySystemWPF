using System.Windows.Input;
using DbAccess.Access.Person;
using LibrarySystemWPF.MainView.ViewModels;

namespace LibrarySystemWPF.MainView.Commands;

internal class PersonSearchCommand(MainViewModel viewModel, IPerson peronAccess) : ICommand
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
            viewModel.Persons = peronAccess.GetAll();
            return;
        }

        var isbnInput = int.TryParse(searchString, out var isbnNumber);
        viewModel.Persons = viewModel.Persons
            .Where(person =>
                person.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || $"{person.FirstName} {person.LastName}".Contains(searchString,
                    StringComparison.CurrentCultureIgnoreCase))
            .ToList();
    }

    public event EventHandler? CanExecuteChanged;
}