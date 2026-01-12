namespace Models;

public class PersonModel
{
    public int? Id { get; set; }
    public string IdNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string FullName
    {
        get => $"{FirstName} {LastName}";
        set
        {
            FirstName = value;
            LastName = value;
        }
    }
}