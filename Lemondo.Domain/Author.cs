namespace Lemondo.Domain;

public sealed class Author : IModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName 
    {
        get { return $"{FirstName} {LastName}"; }
        set {  }
    }
    public DateTime DateOfBirth { get; set; }

    public ICollection<Book>? Books { get; set; }
}
