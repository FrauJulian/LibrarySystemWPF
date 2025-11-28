using Models;

namespace DbAccess.Access.Book;

public interface IBook
{
    public IList<BookModel> GetAll();
    public IList<string> GetAllSubjects();
    public void DeleteByInternId(string internId);
    public void Insert(BookModel model);
}