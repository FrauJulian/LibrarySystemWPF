namespace Models;

public class BorrowModel
{
    public int? Id { get; set; }
    public PersonModel Person { get; set; } = null!;
    public BookModel Book { get; set; } = null!;
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned => ReturnDate != null;
    public DateTime? LatestReturnDate { get; set; }
}