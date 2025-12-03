using Insta.Shared.Dal;
using Insta.Shared.Entities;

namespace InstaFail.Dal;

public class CommentDal : ICommentDal
{
    private static List<Comment> s_comments { get; set; } =
    [
        new() { Id = 16, PhotoId = 15, Author = "JP", Message = "Like me last weekend" },
        new() { Id = 23, PhotoId = 15, Author = "Drunkoon", Message = "I'm never drinking again" },
        new() { Id = 42, PhotoId = 4, Author = "Frits", Message = "First" },
    ];

    public Task<IEnumerable<Comment>> GetAllForPhotoAsync(int photoId)
    {
        Console.WriteLine("[server-side commentdal] GetAllForPhotoAsync");
        return Task.FromResult(s_comments.Where(x => x.PhotoId == photoId).AsEnumerable());
    }

    public Task<Comment> AddForPhotoAsync(int photoId, Comment comment)
    {
        comment.PhotoId = photoId;
        comment.Id = s_comments.Max(x => x.Id) + 1;
        s_comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task<Comment> EditAsync(Comment comment)
    {
        var persistedComment = s_comments.Single(x => x.Id == comment.Id);
        persistedComment.Author = comment.Author;
        persistedComment.Message = comment.Message;
        return Task.FromResult(persistedComment);
    }
}