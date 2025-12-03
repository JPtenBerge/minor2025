namespace Insta.Shared.Entities;

public class Photo
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public byte[] PhotoData { get; set; } = null!;
}