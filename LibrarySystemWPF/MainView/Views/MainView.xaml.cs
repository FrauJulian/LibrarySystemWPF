using System.Windows;
using LibrarySystemWPF.MainView.ViewModels;

namespace LibrarySystemWPF.MainView.Views;

public partial class MainView : Window
{
    
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}