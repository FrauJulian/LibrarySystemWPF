namespace Models;

public class PersonModel
{
    public int? Id { get; set; }
    public string IdNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
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
    public string Street { get; set; } = null!;
    public string HouseNumber { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Postal { get; set; } = null!;
    public string Address => $"{Street} {HouseNumber}, {Postal} {City}";
}