using System.Windows;
using System.Windows.Input;
using LibrarySystemWPF.MainView.ViewModels;
using LibrarySystemWPF.PopupView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Commands;

public class AddAuthorCommand(MainViewModel viewModel) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var enteredText = parameter as string;

        if (string.IsNullOrWhiteSpace(enteredText)) return;
        if (viewModel.Authors.Any(a => a.FullName.Contains(enteredText, StringComparison.OrdinalIgnoreCase))) return;

        var popupViewModel = new PopupViewModel
        {
            Title = "Autor hinzufügen",
            Questions =
            {
                new QuestionModel
                {
                    Question = "Was ist der Vorname?",
                    Result = enteredText
                },
                new QuestionModel
                {
                    Question = "Was ist der Nachname?",
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
        var newAuthor = new AuthorModel
        {
            FirstName = popupViewModel.Questions[0].Result!,
            LastName = popupViewModel.Questions[1].Result!
        };

        viewModel.Authors.Add(newAuthor);
        viewModel.NewBook.Author = newAuthor;
    }

    public event EventHandler? CanExecuteChanged;
}