using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using DbAccess.Access.Book;
using LibrarySystemWPF.MainView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Commands;

public class DeleteBookCommand(MainViewModel viewModel, IBook bookAccess) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is not BookModel book) return;

        var isBorrowed = viewModel.Borrows
            .Any(b => b.Book.InternId == book.InternId && b.ReturnDate == null);

        if (isBorrowed)
        {
            MessageBox.Show("Das Buch wird aktuell verliehen.");
            return;
        }

        bookAccess.DeleteByInternId(book.InternId);
        viewModel.SyncCommand.Execute(false);
        MessageBox.Show("Buch gelöscht!");
    }

    public event EventHandler? CanExecuteChanged;
}