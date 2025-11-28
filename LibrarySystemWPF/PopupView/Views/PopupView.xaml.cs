using System.Windows;
using LibrarySystemWPF.MainView.ViewModels;
using LibrarySystemWPF.PopupView.ViewModels;

namespace LibrarySystemWPF.PopupView.Views;

public partial class PopupView : Window
{
    private readonly MainViewModel _mainViewModel;
    private readonly PopupViewModel _viewModel;

    public PopupView(PopupViewModel viewModel, MainViewModel mainViewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _mainViewModel = mainViewModel;
        DataContext = _viewModel;
    }

    private void OkClick(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }

    private void CancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}