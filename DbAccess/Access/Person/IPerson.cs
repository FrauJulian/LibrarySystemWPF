using Models;

namespace DbAccess.Access.Person;

public interface IPerson
{
    public IList<PersonModel> GetAll();
    public PersonModel GetByIdNumber(string idNumber);
    public void DeleteByIdNumber(string idNumber);
    public void Insert(PersonModel model);
}