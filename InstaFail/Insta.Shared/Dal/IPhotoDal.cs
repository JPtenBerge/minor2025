using Insta.Shared.Entities;

namespace Insta.Shared.Dal;

public interface IPhotoDal
{
    Task<IEnumerable<Photo>> GetAllAsync();
    Task<Photo> GetAsync(int id);
    Task<Photo> AddAsync(Photo photo);
}