using System.Globalization;
using System.Windows.Data;
using LibrarySystemWPF.MainView.ViewModels;
using Models;

namespace LibrarySystemWPF.MainView.Converters;

public class IsBookBorrowedConverter() : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var book = values[0] as BookModel;
        var viewModel = values[1] as MainViewModel;
        var isBorrowed = viewModel!.Borrows.Any(b => b.Book.InternId == book!.InternId && b.ReturnDate == null);
        return !isBorrowed;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}