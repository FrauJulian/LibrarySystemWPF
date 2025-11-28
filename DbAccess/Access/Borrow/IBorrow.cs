using Models;

namespace DbAccess.Access.Borrow;

public interface IBorrow
{
    public IList<BorrowModel> GetAll();
    public IList<BorrowModel> GetByPerson(PersonModel person);
    public void UpdateReturnDate(int id, DateTime returnDate);
    public void DeleteBorrow(int id);
    public void Insert(BorrowModel model);
}