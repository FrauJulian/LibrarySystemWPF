using System.Windows.Input;
using DbAccess.Access.Borrow;
using LibrarySystemWPF.MainView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Commands;

public class ReturnBookCommand(MainViewModel viewModel, IBorrow borrowAccess) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is not BorrowModel borrow) return;
        
        borrowAccess.UpdateReturnDate(borrow.Id);
        viewModel.SyncCommand.Execute(false);
    }

    public event EventHandler? CanExecuteChanged;
}