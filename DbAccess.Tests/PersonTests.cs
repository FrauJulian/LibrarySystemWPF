using DbAccess.Access.Person;
using Models;
using Xunit;

namespace DbAccess.Tests;

public class PersonTests
{
    private static string CreateId()
    {
        return string.Concat("P", Guid.NewGuid().ToString("N").AsSpan(0, 8));
    }

    [Fact]
    public void Insert_Then_GetByIdNumber_Works()
    {
        var core = new Core();
        var personAccess = new Person(core);

        var idNumber = CreateId();

        var model = new PersonModel
        {
            IdNumber = idNumber,
            FirstName = "John",
            LastName = "Doe"
        };

        personAccess.Insert(model);

        var result = personAccess.GetByIdNumber(idNumber);

        Assert.Equal(idNumber, result.IdNumber);

        personAccess.DeleteByIdNumber(idNumber);
    }

    [Fact]
    public void DeleteByIdNumber_RemovesData()
    {
        var core = new Core();
        var personAccess = new Person(core);

        var idNumber = CreateId();

        var model = new PersonModel
        {
            IdNumber = idNumber,
            FirstName = "X",
            LastName = "Y"
        };

        personAccess.Insert(model);
        personAccess.DeleteByIdNumber(idNumber);

        var result = personAccess.GetByIdNumber(idNumber);

        Assert.Null(result.Id);
    }

    [Fact]
    public void GetAll_ReturnsList()
    {
        var core = new Core();
        var personAccess = new Person(core);

        var list = personAccess.GetAll();

        Assert.NotNull(list);
    }
}