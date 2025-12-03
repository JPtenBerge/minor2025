namespace Insta.Shared.Entities;

public class Comment
{
    public int Id { get; set; }
    public int PhotoId { get; set; }
    public Photo Photo { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Message { get; set; } = null!;
}