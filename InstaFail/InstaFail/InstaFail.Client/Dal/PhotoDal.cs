using Insta.Shared.Dal;
using Insta.Shared.Entities;

namespace InstaFail.Client.Dal;

public class PhotoDal : IPhotoDal
{
    public Task<IEnumerable<Photo>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Photo> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Photo> AddAsync(Photo photo)
    {
        throw new NotImplementedException();
    }
}