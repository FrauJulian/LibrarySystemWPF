using System.Windows;
using System.Windows.Input;
using LibrarySystemWPF.MainView.ViewModels;
using LibrarySystemWPF.PopupView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Commands;

public class AddPublisherCommand(MainViewModel viewModel) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var enteredText = parameter as string;

        if (string.IsNullOrWhiteSpace(enteredText)) return;
        if (viewModel.Publishers.Any(a => a.Name.Contains(enteredText, StringComparison.OrdinalIgnoreCase))) return;

        var popupViewModel = new PopupViewModel
        {
            Title = "Verlag hinzufügen",
            Questions =
            {
                new QuestionModel
                {
                    Question = "Was ist der Name?",
                    Result = enteredText
                },
                new QuestionModel
                {
                    Question = "Was ist der Hauptsitz?",
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
        var newPublisher = new PublisherModel
        {
            Name = popupViewModel.Questions[0].Result!,
            Location = popupViewModel.Questions[1].Result!
        };

        viewModel.Publishers.Add(newPublisher);
        viewModel.NewBook.Publisher = newPublisher;
    }

    public event EventHandler? CanExecuteChanged;
}