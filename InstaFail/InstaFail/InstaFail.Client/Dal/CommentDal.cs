using Flurl.Http;
using Insta.Shared.Dal;
using Insta.Shared.Entities;

namespace InstaFail.Client.Dal;

public class CommentDal : ICommentDal
{
    public async Task<IEnumerable<Comment>> GetAllForPhotoAsync(int photoId)
    {
        Console.WriteLine("getting all");
        return await $"https://localhost:7262/api/photos/{photoId}/comments"
            .GetJsonAsync<IEnumerable<Comment>>();
    }

    public async Task<Comment> AddForPhotoAsync(int photoId, Comment comment)
    {
        Console.WriteLine("adding");
        
        return await $"https://localhost:7262/api/photos/{photoId}/comments"
            .PostJsonAsync(comment)
            .ReceiveJson<Comment>();
    }

    public async Task<Comment> EditAsync(Comment comment)
    {
        Console.WriteLine("editing");
        
        return await $"https://localhost:7262/api/photos/{comment.PhotoId}/comments/{comment.Id}"
            .PutJsonAsync(comment)
            .ReceiveJson<Comment>();
    }
}