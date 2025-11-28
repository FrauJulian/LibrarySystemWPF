using DbAccess.Access.Book;
using Models;
using Xunit;

namespace DbAccess.Tests;

public class BookTests
{
    private static string CreateInternId()
    {
        return string.Concat("B", Guid.NewGuid().ToString("N").AsSpan(0, 9));
    }

    [Fact]
    public void Insert_Then_GetByInternId_Works()
    {
        var core = new Core();
        var bookAccess = new Book(core);

        var internId = CreateInternId();

        var model = new BookModel
        {
            InternId = internId,
            Isbn = 55555,
            Title = "TestTitle",
            Subject = "SubjectEnum.Chemie",
            PublishDate = DateTime.Today,
            Publisher = new PublisherModel { Name = "Pub", Location = "X" },
            Author = new AuthorModel { FirstName = "A", LastName = "B" }
        };

        bookAccess.Insert(model);

        var result = bookAccess.GetByInternId(internId);

        Assert.Single(result);

        bookAccess.DeleteByInternId(internId);
    }

    [Fact]
    public void DeleteByInternId_RemovesData()
    {
        var core = new Core();
        var bookAccess = new Book(core);

        var internId = CreateInternId();

        var model = new BookModel
        {
            InternId = internId,
            Isbn = 111,
            Title = "ToDelete",
            Subject = "Abenteuer",
            PublishDate = DateTime.Today,
            Publisher = new PublisherModel { Name = "P", Location = "L" },
            Author = new AuthorModel { FirstName = "A", LastName = "B" }
        };

        bookAccess.Insert(model);
        bookAccess.DeleteByInternId(internId);

        var result = bookAccess.GetByInternId(internId);

        Assert.Empty(result);
    }

    [Fact]
    public void GetAll_ReturnsList()
    {
        var core = new Core();
        var bookAccess = new Book(core);

        var list = bookAccess.GetAll();

        Assert.NotNull(list);
    }
}