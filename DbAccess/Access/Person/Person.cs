using Models;

namespace DbAccess.Access.Person;

public class Person(IDbCore dbCore) : IPerson
{
    public IList<PersonModel> GetAll()
    {
        var personList = new List<PersonModel>();

        const string sql = "SELECT * FROM Person";
        var reader = dbCore.RunSql(sql, []);

        while (reader.Read())
            personList.Add(new PersonModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                IdNumber = reader.GetString(reader.GetOrdinal("IdNumber")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName"))
            });

        return personList;
    }

    public PersonModel GetByIdNumber(string idNumber)
    {
        var person = new PersonModel();

        const string sql = "SELECT * FROM Person WHERE IdNumber = @IdNumber";
        var parameters = new IParamValue[]
        {
            new ParamValue<string>
            {
                Name = "@IdNumber",
                Value = idNumber
            }
        };

        var reader = dbCore.RunSql(sql, parameters);

        while (reader.Read())
        {
            person.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            person.IdNumber = reader.GetString(reader.GetOrdinal("IdNumber"));
            person.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            person.LastName = reader.GetString(reader.GetOrdinal("LastName"));
        }

        return person;
    }

    public void DeleteByIdNumber(string idNumber)
    {
        const string sql = "DELETE FROM Person WHERE IdNumber = @IdNumber";
        var parameters = new IParamValue[]
        {
            new ParamValue<string>
            {
                Name = "@IdNumber",
                Value = idNumber
            }
        };

        dbCore.RunSql(sql, parameters);
    }

    public void Insert(PersonModel model)
    {
        const string sql =
            "INSERT INTO Person (IdNumber, Firstname, Lastname) VALUES (@IdNumber, @Firstname, @Lastname)";
        var parameters = new IParamValue[]
        {
            new ParamValue<string>
            {
                Name = "@IdNumber",
                Value = model.IdNumber
            },
            new ParamValue<string>
            {
                Name = "@Firstname",
                Value = model.FirstName
            },
            new ParamValue<string>
            {
                Name = "@Lastname",
                Value = model.LastName
            }
        };

        dbCore.RunSql(sql, parameters);
    }
}