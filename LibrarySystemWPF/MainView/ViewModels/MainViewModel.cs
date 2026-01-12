using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using Models;

namespace LibrarySystemWPF.MainView.ViewModels;

public sealed class MainViewModel : INotifyPropertyChanged
{
    private IList<AuthorModel> _authors = null!;

    private IList<BookModel> _books = null!;

    private IList<BorrowModel> _borrows = null!;

    private BookModel _newBook = new();

    private PersonModel _newPerson = new();

    private IList<PersonModel> _persons = null!;

    private IList<PublisherModel> _publishers = null!;

    private string _searchText = null!;

    public IValueConverter IsBookBorrowedConverter { get; set; } = null!;
    public ICommand BookSearchCommand { get; set; } = null!;
    public ICommand SyncCommand { get; set; } = null!;
    public ICommand PersonSearchCommand { get; set; } = null!;
    public ICommand BorrowSearchCommand { get; set; } = null!;
    public ICommand AddPersonCommand { get; set; } = null!;
    public ICommand AddBookCommand { get; set; } = null!;
    public ICommand BorrowCommand { get; set; } = null!;
    public ICommand AddAuthorCommand { get; set; } = null!;
    public ICommand AddPublisherCommand { get; set; } = null!;
    public ICommand DeleteBookCommand { get; set; } = null!;
    public ICommand DeletePersonCommand { get; set; } = null!;
    public ICommand ReturnBookCommand { get; set; } = null!;

    public PersonModel NewPerson
    {
        get => _newPerson;
        set
        {
            _newPerson = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_newPerson));
        }
    }

    public BookModel NewBook
    {
        get => _newBook;
        set
        {
            _newBook = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_newBook));
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (Equals(_searchText, value)) return;
            _searchText = value;
            BookSearchCommand.Execute(_searchText);
            PersonSearchCommand.Execute(_searchText);
            BorrowSearchCommand.Execute(_searchText);
            OnPropertyChanged();
            OnPropertyChanged(nameof(_searchText));
        }
    }

    public IList<string> SubjectValues { get; set; } = null!;

    public IList<PublisherModel> Publishers
    {
        get => _publishers;
        set
        {
            if (Equals(_publishers, value)) return;
            _publishers = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_publishers));
        }
    }

    public IList<AuthorModel> Authors
    {
        get => _authors;
        set
        {
            if (Equals(_authors, value)) return;
            _authors = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_authors));
        }
    }

    public IList<BookModel> Books
    {
        get => _books;
        set
        {
            if (Equals(_books, value)) return;
            _books = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_books));
        }
    }

    public IList<PersonModel> Persons
    {
        get => _persons;
        set
        {
            if (Equals(_persons, value)) return;
            _persons = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_persons));
        }
    }

    public IList<BorrowModel> Borrows
    {
        get => _borrows;
        set
        {
            if (Equals(_borrows, value)) return;
            _borrows = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_borrows));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}