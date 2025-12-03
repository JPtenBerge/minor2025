using Insta.Shared.Entities;

namespace InstaFail.Dal;

public class PhotoDal
{
    public static List<Photo> Photos { get; set; } =
    [
        new() { Id = 4, Title = "Me at the zoo", Description = "Me, at the zoo", PhotoData = [] },
        new() { Id = 8, Title = "Cat", Description = "Cat staring", PhotoData = [] },
        new() { Id = 15, Title = "Raccoon", Description = "Drunk raccoon", PhotoData = [] },
    ];
}