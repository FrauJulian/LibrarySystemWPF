using System.Windows;
using System.Windows.Input;
using DbAccess.Access.Person;
using LibrarySystemWPF.MainView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Commands;

internal class AddPersonCommand(MainViewModel viewModel, IPerson personAccess) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is not PersonModel person) return;

        if (string.IsNullOrWhiteSpace(person.IdNumber)
            || string.IsNullOrWhiteSpace(person.FirstName)
            || string.IsNullOrWhiteSpace(person.LastName))
        {
            MessageBox.Show("Eine der nötigen Angaben fehlt.");
            return;
        }

        if (viewModel.Persons.Any(i => i.IdNumber == person.IdNumber))
        {
            MessageBox.Show("Eine Person mit dieser Ausweisnummer existiert bereits.");
            return;
        }

        personAccess.Insert(person);
        viewModel.Persons = personAccess.GetAll();
        viewModel.NewPerson = new PersonModel();
        
        MessageBox.Show("Person hinzugefügt!");
    }

    public event EventHandler? CanExecuteChanged;
}