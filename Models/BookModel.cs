using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models;

public class BookModel : INotifyPropertyChanged
{
    private AuthorModel _author = null!;
    private PublisherModel _publisher = null!;
    public string AuthorPlaceholder { get; set; } = "";
    public string PublisherPlaceholder { get; set; } = "";
    public int? Id { get; set; }
    public string InternId { get; set; } = null!;
    public int? Isbn { get; set; }
    public string Title { get; set; } = null!;
    public string? Subject { get; set; }

    public PublisherModel Publisher
    {
        get => _publisher;
        set
        {
            _publisher = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_publisher));
        }
    }

    public AuthorModel Author
    {
        get => _author;
        set
        {
            _author = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(_author));
        }
    }

    public DateTime? PublishDate { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}