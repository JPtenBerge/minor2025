using Insta.Shared.Entities;

namespace InstaFail.Dal;

public interface IPhotoDal
{
    Task<IEnumerable<Photo>> GetAllAsync();
    Task<Photo> AddAsync(Photo photo);
}