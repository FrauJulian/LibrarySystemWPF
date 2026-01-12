using System.Windows;
using System.Windows.Input;
using DbAccess.Access.Book;
using DbAccess.Access.Borrow;
using LibrarySystemWPF.MainView.ViewModels;
using LibrarySystemWPF.PopupView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Commands;

public class BorrowCommand(MainViewModel viewModel, IBook bookAccess, IBorrow borrowAccess) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is not BookModel book) return;

        var popupViewModel = new PopupViewModel
        {
            Title = "Buch verleihen",
            Questions =
            {
                new QuestionModel
                {
                    Question = "Was ist die Ausweisnummer?",
                    Result = ""
                },
                new QuestionModel
                {
                    Question = "Wie viele Tage?",
                    Result = ""
                }
            }
        };

        var popupView = new PopupView.Views.PopupView(popupViewModel, viewModel)
        {
            Owner = Application.Current.MainWindow
        };

        var state = popupView.ShowDialog();

        if (!(bool)state!) return;

        if (viewModel.Persons.All(p => p.IdNumber != popupViewModel.Questions[0].Result!))
        {
            MessageBox.Show("Ungültige Person!");
            return;
        }

        if (!int.TryParse(popupViewModel.Questions[1].Result!, out var days))
        {
            MessageBox.Show("Ungültige Anzahl an Tagen!");
            return;
        }
        
        var newBorrow = new BorrowModel()
        {
            Book = book,
            Person = viewModel.Persons.FirstOrDefault(p => p.IdNumber == popupViewModel.Questions[0].Result!)!,
            BorrowDate =  DateTime.Now,
            LatestReturnDate =  DateTime.Now.AddDays(days),
        };

        borrowAccess.Insert(newBorrow);
        viewModel.SyncCommand.Execute(false);
    }

    public event EventHandler? CanExecuteChanged;
}