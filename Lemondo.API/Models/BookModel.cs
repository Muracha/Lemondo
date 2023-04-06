namespace Lemondo.API.Models;

public class BookModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public byte[]? Photo { get; set; }
    public int Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool IsTaken { get; set; }
    public string Description { get; set; } = null!;

    public ICollection<AuthorModel>? Authors { get; set; }
}
