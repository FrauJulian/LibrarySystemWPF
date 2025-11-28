using Models;

namespace DbAccess.Access.Author;

public class Author(IDbCore dbCore) : IAuthor
{
    public IList<AuthorModel> GetAll()
    {
        var authorList = new List<AuthorModel>();

        const string sql = "SELECT * FROM Author";
        var reader = dbCore.RunSql(sql, []);

        while (reader.Read())
            authorList.Add(new AuthorModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FirstName = reader.GetString(reader.GetOrdinal("Firstname")),
                LastName = reader.GetString(reader.GetOrdinal("Lastname"))
            });

        return authorList;
    }
}