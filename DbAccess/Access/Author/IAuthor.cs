using Models;

namespace DbAccess.Access.Author;

public interface IAuthor
{
    public IList<AuthorModel> GetAll();
}