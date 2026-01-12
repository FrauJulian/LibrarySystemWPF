using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using DbAccess.Access.Book;
using LibrarySystemWPF.MainView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Commands;

public partial class AddBookCommand(MainViewModel viewModel, IBook bookAccess) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is not BookModel book) return;

        if (string.IsNullOrWhiteSpace(book.Title)
            || string.IsNullOrWhiteSpace(book.Subject)
            || book.Author is null
            || book.Publisher is null
            || book.PublishDate is null
            || book.Isbn is null)
        {
            MessageBox.Show("Eine der nötigen Angaben fehlt.");
            return;
        }
        
        if (book.InternId is null)
        {
            var year = DateTime.Now.Year;

            var highest = viewModel.Books
                .OrderByDescending(b => b.InternId)
                .FirstOrDefault();

            var newNumber = 1;

            if (highest != null)
            {
                var parts = highest.InternId.Split('-');
                var lastNumber = int.Parse(parts[0]);
                var lastYear = int.Parse(parts[1]);

                if (lastYear == year) newNumber = lastNumber + 1;
            }

            var padded = newNumber.ToString("D5");
            book.InternId = $"{padded}-{year}";
        } else if (!MyRegex().IsMatch(book.InternId))
        {
            MessageBox.Show("Ungültige Kennung! Erlaubtes Format: xxxxx-jjjj");
            return;
        }
        
        bookAccess.Insert(book);
        viewModel.SyncCommand.Execute(false);
        viewModel.NewBook = new BookModel();
        
        MessageBox.Show("Buch hinzugefügt!");
    }

    public event EventHandler? CanExecuteChanged;

    [GeneratedRegex(@"^\d{5}-\d{4}$")]
    private static partial Regex MyRegex();
}