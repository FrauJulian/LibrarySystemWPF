using Models;

namespace LibrarySystemWPF.PopupView.ViewModels;

public class PopupViewModel
{
    public string Title { get; set; } = null!;
    public List<QuestionModel> Questions { get; set; } = [];
}