using System.Windows;
using System.Windows.Input;
using DbAccess.Access.Person;
using LibrarySystemWPF.MainView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Commands;

public class DeletePersonCommand(MainViewModel viewModel, IPerson personAccess) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is not PersonModel person) return;

        var isBorrowed = viewModel.Borrows
            .Any(b => b.Person.IdNumber == person.IdNumber && b.ReturnDate == null);

        if (isBorrowed)
        {
            MessageBox.Show("Diese Person hat aktuell ein Buch!");
            return;
        }

        personAccess.DeleteByIdNumber(person.IdNumber);
        viewModel.Persons = personAccess.GetAll();
        MessageBox.Show("Person gelöscht!");
    }

    public event EventHandler? CanExecuteChanged;
}