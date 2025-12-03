using Insta.Shared.Dal;
using Insta.Shared.Entities;

namespace InstaFail.Client.Dal;

public class CommentDal : ICommentDal
{
    public Task<IEnumerable<Comment>> GetAllForPhotoAsync(int photoId)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> AddForPhotoAsync(int photoId, Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> EditAsync(Comment comment)
    {
        // throw new NotImplementedException();
        return Task.FromResult(comment);
    }
}