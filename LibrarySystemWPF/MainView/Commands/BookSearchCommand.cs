using System.Windows.Input;
using DbAccess.Access.Book;
using LibrarySystemWPF.MainView.ViewModels;

namespace LibrarySystemWPF.MainView.Commands;

internal class BookSearchCommand(MainViewModel viewModel) : ICommand
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
        viewModel.Books = viewModel.Books
            .Where(book =>
                book.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || book.InternId.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || book.Subject!.ToString().Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || $"{book.Author.FirstName} {book.Author.LastName}".Contains(searchString,
                    StringComparison.CurrentCultureIgnoreCase)
                || (isbnInput && book.Isbn == isbnNumber))
            .ToList();
    }

    public event EventHandler? CanExecuteChanged;
}