namespace Lemondo.API.Models;

public class AuthorModel
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

    [JsonIgnore]
    public ICollection<BookModel>? Books { get; set; }
}
