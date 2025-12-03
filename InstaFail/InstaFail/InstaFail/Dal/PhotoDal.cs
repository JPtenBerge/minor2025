using Insta.Shared.Entities;

namespace InstaFail.Dal;

public class PhotoDal : IPhotoDal
{
    private static List<Photo> s_photos { get; set; } =
    [
        new() { Id = 4, Title = "Me at the zoo", Description = "Me, at the zoo", PhotoData = [] },
        new() { Id = 8, Title = "Cat", Description = "Cat staring", PhotoData = [] },
        new() { Id = 15, Title = "Raccoon", Description = "Drunk raccoon", PhotoData = [] },
    ];

    public Task<IEnumerable<Photo>> GetAllAsync()
    {
        return Task.FromResult(s_photos.AsEnumerable());
    }

    public Task<Photo> AddAsync(Photo photo)
    {
        photo.Id = s_photos.Max(x => x.Id) + 1;
        s_photos.Add(photo);
        return Task.FromResult(photo);
    }
}