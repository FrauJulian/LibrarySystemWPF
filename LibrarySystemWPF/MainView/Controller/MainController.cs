using DbAccess;
using DbAccess.Access.Author;
using DbAccess.Access.Book;
using DbAccess.Access.Borrow;
using DbAccess.Access.Person;
using DbAccess.Access.Publisher;
using LibrarySystemWPF.MainView.Commands;
using LibrarySystemWPF.MainView.Converters;
using LibrarySystemWPF.MainView.ViewModels;

namespace LibrarySystemWPF.MainView.Controller;

internal class MainController(Core dbCore)
{
    private readonly Author _authorAccess = new(dbCore);
    private readonly Book _bookAccess = new(dbCore);
    private readonly Borrow _borrowAccess = new(dbCore);
    private readonly Person _personAccess = new(dbCore);
    private readonly Publisher _publisherAccess = new(dbCore);

    public Views.MainView Create()
    {
        var view = new Views.MainView();
        var viewModel = new MainViewModel();

        LoadData(viewModel);
        LoadCommands(viewModel);

        view.DataContext = viewModel;

        return view;
    }

    private void LoadData(MainViewModel viewModel)
    {
        viewModel.Books = _bookAccess.GetAll();
        viewModel.Persons = _personAccess.GetAll();
        viewModel.Borrows = _borrowAccess.GetAll();
        viewModel.Authors = _authorAccess.GetAll();
        viewModel.Publishers = _publisherAccess.GetAll();
        viewModel.SubjectValues = _bookAccess.GetAllSubjects();
    }

    private void LoadCommands(MainViewModel viewModel)
    {
        viewModel.BookSearchCommand = new BookSearchCommand(viewModel, _bookAccess);
        viewModel.PersonSearchCommand = new PersonSearchCommand(viewModel, _personAccess);
        viewModel.AddPersonCommand = new AddPersonCommand(viewModel, _personAccess);
        viewModel.AddBookCommand = new AddBookCommand(viewModel, _bookAccess);
        viewModel.BorrowCommand = new BorrowCommand(viewModel, _borrowAccess);
        viewModel.AddAuthorCommand = new AddAuthorCommand(viewModel);
        viewModel.AddPublisherCommand = new AddPublisherCommand(viewModel);
        viewModel.DeleteBookCommand = new DeleteBookCommand(viewModel, _bookAccess);
        viewModel.DeletePersonCommand = new DeletePersonCommand(viewModel, _personAccess);
    }
}