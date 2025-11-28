using System.Text.RegularExpressions;
using Models;

namespace DbAccess.Access.Book;

public partial class Book(IDbCore dbCore) : IBook
{
    public IList<BookModel> GetAll()
    {
        var bookList = new List<BookModel>();

        var sql = File.ReadAllText(Path.Combine("Scripts/Book", "GetAll.sql"));
        var reader = dbCore.RunSql(sql, []);

        while (reader.Read())
            bookList.Add(new BookModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                InternId = reader.GetString(reader.GetOrdinal("InternId")),
                Isbn = reader.GetInt32(reader.GetOrdinal("ISBN")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Subject = reader.GetString(reader.GetOrdinal("Subject")),
                PublishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate")),
                Publisher = new PublisherModel
                {
                    Id = reader.GetInt32(reader.GetOrdinal("PublisherId")),
                    Name = reader.GetString(reader.GetOrdinal("PublisherName")),
                    Location = reader.GetString(reader.GetOrdinal("PublisherLocation"))
                },
                Author = new AuthorModel
                {
                    Id = reader.GetInt32(reader.GetOrdinal("AuthorId")),
                    FirstName = reader.GetString(reader.GetOrdinal("AuthorFirstname")),
                    LastName = reader.GetString(reader.GetOrdinal("AuthorLastname"))
                }
            });

        return bookList;
    }

    public IList<string> GetAllSubjects()
    {
        var subjectList = new List<string>();
        var definition = string.Empty;

        var sql = File.ReadAllText(Path.Combine("Scripts/Book", "GetAllSubjects.sql"));
        var reader = dbCore.RunSql(sql, []);

        if (reader.Read()) definition = reader[1].ToString();

        if (string.IsNullOrWhiteSpace(definition)) return subjectList;

        var matches = MyRegex().Matches(definition);

        foreach (Match match in matches) subjectList.Add(match.Groups[1].Value);

        return subjectList;
    }

    public void DeleteByInternId(string internId)
    {
        const string sql = "DELETE FROM Book WHERE InternId = @InternId";
        var parameters = new IParamValue[]
        {
            new ParamValue<string>
            {
                Name = "@InternId",
                Value = internId
            }
        };

        dbCore.RunSql(sql, parameters);
    }

    public void Insert(BookModel model)
    {
        var sql = File.ReadAllText(Path.Combine("Scripts/Book", "Insert.sql"));
        var parameters = new IParamValue[]
        {
            new ParamValue<string>
            {
                Name = "@PublisherName",
                Value = model.Publisher.Name
            },
            new ParamValue<string>
            {
                Name = "@PublisherLocation",
                Value = model.Publisher.Location
            },
            new ParamValue<string>
            {
                Name = "@AuthorFirstname",
                Value = model.Author.FirstName
            },
            new ParamValue<string>
            {
                Name = "@AuthorLastname",
                Value = model.Author.LastName
            },
            new ParamValue<string>
            {
                Name = "@InternId",
                Value = model.InternId
            },
            new ParamValue<int>
            {
                Name = "@ISBN",
                Value = (int)model.Isbn!
            },
            new ParamValue<string>
            {
                Name = "@Title",
                Value = model.Title
            },
            new ParamValue<string>
            {
                Name = "@Subject",
                Value = model.Subject!
            },
            new ParamValue<DateTime>
            {
                Name = "@PublishDate",
                Value = (DateTime)model.PublishDate!
            }
        };

        dbCore.RunSql(sql, parameters);
    }

    [GeneratedRegex(@"'([^']*)'")]
    private static partial Regex MyRegex();
}