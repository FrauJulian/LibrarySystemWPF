using Models;

namespace DbAccess.Access.Borrow;

public class Borrow(IDbCore dbCore) : IBorrow
{
    public IList<BorrowModel> GetAll()
    {
        var borrowList = new List<BorrowModel>();

        var sql = File.ReadAllText(Path.Combine("Scripts/Borrow", "GetAll.sql"));
        var reader = dbCore.RunSql(sql, []);

        while (reader.Read())
            borrowList.Add(new BorrowModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Person = new PersonModel
                {
                    Id = reader.GetInt32(reader.GetOrdinal("PersonId")),
                    IdNumber = reader.GetString(reader.GetOrdinal("PersonIdNumber")),
                    FirstName = reader.GetString(reader.GetOrdinal("PersonFirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("PersonLastName")),
                    Address = reader.GetString(reader.GetOrdinal("PersonAddress")),
                    Phone = reader.GetString(reader.GetOrdinal("PersonPhone"))
                },
                Book = new BookModel
                {
                    Id = reader.GetInt32(reader.GetOrdinal("BookId")),
                    InternId = reader.GetString(reader.GetOrdinal("BookInternId")),
                    Isbn = reader.GetInt32(reader.GetOrdinal("BookISBN")),
                    Title = reader.GetString(reader.GetOrdinal("BookTitle")),
                    Subject = reader.GetString(reader.GetOrdinal("BookSubject")),
                    PublishDate = reader.GetDateTime(reader.GetOrdinal("BookPublishDate")),
                    Publisher = new PublisherModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("BookPublisherId")),
                        Name = reader.GetString(reader.GetOrdinal("BookPublisherName")),
                        Location = reader.GetString(reader.GetOrdinal("BookPublisherLocation"))
                    },
                    Author = new AuthorModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("BookAuthorId")),
                        FirstName = reader.GetString(reader.GetOrdinal("BookAuthorFirstname")),
                        LastName = reader.GetString(reader.GetOrdinal("BookAuthorLastname"))
                    }
                },
                BorrowDate = reader.GetDateTime(reader.GetOrdinal("BorrowDate")),
                ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate"))
                    ? null
                    : reader.GetDateTime(reader.GetOrdinal("ReturnDate")),
                LatestReturnDate = reader.GetDateTime(reader.GetOrdinal("LatestReturnDate"))
            });

        return borrowList;
    }

    public IList<BorrowModel> GetByPerson(PersonModel person)
    {
        var borrowList = new List<BorrowModel>();

        var sql = File.ReadAllText(Path.Combine("Scripts/Borrow", "GetByPerson.sql"));
        var parameters = new IParamValue[]
        {
            new ParamValue<int?>
            {
                Name = "@PersonId",
                Value = person.Id
            }
        };

        var reader = dbCore.RunSql(sql, parameters);

        while (reader.Read())
            borrowList.Add(new BorrowModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Person = new PersonModel
                {
                    Id = reader.GetInt32(reader.GetOrdinal("PersonId")),
                    IdNumber = reader.GetString(reader.GetOrdinal("PersonIdNumber")),
                    FirstName = reader.GetString(reader.GetOrdinal("PersonFirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("PersonLastName")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Phone = reader.GetString(reader.GetOrdinal("LastName"))
                },
                Book = new BookModel
                {
                    Id = reader.GetInt32(reader.GetOrdinal("BookId")),
                    InternId = reader.GetString(reader.GetOrdinal("BookInternId")),
                    Isbn = reader.GetInt32(reader.GetOrdinal("BookISBN")),
                    Title = reader.GetString(reader.GetOrdinal("BookTitle")),
                    Subject = reader.GetString(reader.GetOrdinal("BookSubject")),
                    PublishDate = reader.GetDateTime(reader.GetOrdinal("BookPublishDate")),
                    Publisher = new PublisherModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("BookPublisherId")),
                        Name = reader.GetString(reader.GetOrdinal("BookPublisherName")),
                        Location = reader.GetString(reader.GetOrdinal("BookPublisherLocation"))
                    },
                    Author = new AuthorModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("BookAuthorId")),
                        FirstName = reader.GetString(reader.GetOrdinal("BookAuthorFirstname")),
                        LastName = reader.GetString(reader.GetOrdinal("BookAuthorLastname"))
                    }
                },
                BorrowDate = reader.GetDateTime(reader.GetOrdinal("BorrowDate")),
                ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate"))
                    ? null
                    : reader.GetDateTime(reader.GetOrdinal("ReturnDate")),
                LatestReturnDate = reader.GetDateTime(reader.GetOrdinal("LatestReturnDate"))
            });

        return borrowList;
    }

    public void UpdateReturnDate(int? id)
    {
        const string sql = "UPDATE Borrow SET ReturnDate = @ReturnDate WHERE Id = @Id;";
        var parameters = new IParamValue[]
        {
            new ParamValue<DateTime>
            {
                Name = "@ReturnDate",
                Value = DateTime.Now
            },
            new ParamValue<int?>
            {
                Name = "@Id",
                Value = id
            }
        };

        dbCore.RunSql(sql, parameters);
    }

    public void DeleteBorrow(int id)
    {
        const string sql = "DELETE FROM Borrow WHERE Id = @Id";
        var parameters = new IParamValue[]
        {
            new ParamValue<int>
            {
                Name = "@Id",
                Value = id
            }
        };

        dbCore.RunSql(sql, parameters);
    }

    public void Insert(BorrowModel model)
    {
        const string sql =
            "INSERT INTO Borrow (PersonId, BookId, BorrowDate, LatestReturnDate) VALUES (@PersonId, @BookId, @BorrowDate, @LatestReturnDate)";
        var parameters = new IParamValue[]
        {
            new ParamValue<int?>
            {
                Name = "@PersonId",
                Value = model.Person.Id
            },
            new ParamValue<int?>
            {
                Name = "@BookId",
                Value = model.Book.Id
            },
            new ParamValue<DateTime>
            {
                Name = "@BorrowDate",
                Value = model.BorrowDate
            },
            new ParamValue<DateTime>
            {
                Name = "@LatestReturnDate",
                Value = (DateTime)model.LatestReturnDate!
            }
        };

        dbCore.RunSql(sql, parameters);
    }
}