using Insta.Shared.Entities;

namespace Insta.Shared.Dal;

public interface ICommentDal
{
    Task<IEnumerable<Comment>> GetAllForPhotoAsync(int photoId);
    Task<Comment> AddForPhotoAsync(int photoId, Comment comment);
    Task<Comment> EditAsync(Comment comment);
    
}