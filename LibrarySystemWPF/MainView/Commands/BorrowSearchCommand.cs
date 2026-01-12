using System.Windows.Input;
using LibrarySystemWPF.MainView.ViewModels;

namespace LibrarySystemWPF.MainView.Commands;

public class BorrowSearchCommand(MainViewModel viewModel) : ICommand
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

        var isbnInput = int.TryParse(searchString, out var isbnNumber);
        viewModel.Borrows = viewModel.Borrows
            .Where(borrow =>
                borrow.Book.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || borrow.Book.InternId.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || borrow.Book.Subject!.ToString().Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || $"{borrow.Book.Author.FirstName} {borrow.Book.Author.LastName}".Contains(searchString,
                    StringComparison.CurrentCultureIgnoreCase)
                ||                 borrow.Person.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || $"{borrow.Person.FirstName} {borrow.Person.LastName}".Contains(searchString,
                    StringComparison.CurrentCultureIgnoreCase)
                || (isbnInput && borrow.Book.Isbn == isbnNumber))
            .ToList();
    }

    public event EventHandler? CanExecuteChanged;
}