using DbAccess.Access.Book;
using DbAccess.Access.Borrow;
using DbAccess.Access.Person;
using Models;
using Xunit;

namespace DbAccess.Tests;

public class BorrowTests
{
    private static string CreatePersonId()
    {
        return string.Concat("P", Guid.NewGuid().ToString("N").AsSpan(0, 8));
    }

    private static string CreateInternId()
    {
        return string.Concat("B", Guid.NewGuid().ToString("N").AsSpan(0, 9));
    }

    private PersonModel CreatePerson()
    {
        var core = new Core();
        var personAccess = new Person(core);

        var id = CreatePersonId();

        var model = new PersonModel
        {
            IdNumber = id,
            FirstName = "T",
            LastName = "U"
        };

        personAccess.Insert(model);
        return personAccess.GetByIdNumber(id);
    }

    private BookModel CreateBook()
    {
        var core = new Core();
        var bookAccess = new Book(core);

        var id = CreateInternId();

        var model = new BookModel
        {
            InternId = id,
            Isbn = 777,
            Title = "TestBook",
            Subject = "Abenteuer",
            PublishDate = DateTime.Today,
            Publisher = new PublisherModel { Name = "P", Location = "L" },
            Author = new AuthorModel { FirstName = "A", LastName = "B" }
        };

        bookAccess.Insert(model);
        return bookAccess.GetByInternId(id)[0];
    }

    [Fact]
    public void Insert_Then_GetByPerson_Works()
    {
        var core = new Core();
        var borrowAccess = new Borrow(core);

        var person = CreatePerson();
        var book = CreateBook();

        var model = new BorrowModel
        {
            Person = person,
            Book = book,
            BorrowDate = DateTime.Today,
            LatestReturnDate = DateTime.Today.AddDays(5)
        };

        borrowAccess.Insert(model);

        var list = borrowAccess.GetByPerson(person);

        Assert.True(list.Count > 0);
    }

    [Fact]
    public void UpdateReturnDate_WritesValue()
    {
        var core = new Core();
        var borrowAccess = new Borrow(core);

        var person = CreatePerson();
        var book = CreateBook();

        var model = new BorrowModel
        {
            Person = person,
            Book = book,
            BorrowDate = DateTime.Today,
            LatestReturnDate = DateTime.Today.AddDays(10)
        };

        borrowAccess.Insert(model);

        var list = borrowAccess.GetByPerson(person);
        var entry = list[0];

        var newDate = DateTime.Today.AddDays(1);

        borrowAccess.UpdateReturnDate((int)entry.Id!, newDate);

        var listAfter = borrowAccess.GetByPerson(person);

        Assert.Equal(newDate, listAfter[0].ReturnDate);
    }

    [Fact]
    public void DeleteBorrow_RemovesRow()
    {
        var core = new Core();
        var borrowAccess = new Borrow(core);

        var person = CreatePerson();
        var book = CreateBook();

        var model = new BorrowModel
        {
            Person = person,
            Book = book,
            BorrowDate = DateTime.Today,
            LatestReturnDate = DateTime.Today.AddDays(2)
        };

        borrowAccess.Insert(model);

        var list = borrowAccess.GetByPerson(person);
        var entry = list[0];

        borrowAccess.DeleteBorrow((int)entry.Id!);

        var after = borrowAccess.GetByPerson(person);

        Assert.Empty(after);
    }
}