using Insta.Shared.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Insta.Backend.Endpoints;

public static class CommentEndpoints
{
    private static List<Comment> s_comments { get; set; } =
    [
        new() { Id = 16, PhotoId = 15, Author = "JP", Message = "Like me last weekend" },
        new() { Id = 23, PhotoId = 15, Author = "Drunkoon", Message = "I'm never drinking again" },
        new() { Id = 42, PhotoId = 4, Author = "Frits", Message = "First" },
    ];

    public static void MapCommentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/photos/{photoId:int}/comments").WithTags("Comments");

        group.MapGet("/", GetAllForPhoto);
        group.MapGet("/{commentId:int}", Get);
        group.MapPost("/", Post);
        group.MapPut("/{commentId:int}", Put);
        group.MapDelete("/{commentId:int}", Remove);
    }

    public static IEnumerable<Comment> GetAllForPhoto(int photoId)
    {
        return s_comments.Where(x => x.PhotoId == photoId).AsEnumerable();
    }

    public static Results<NotFound<string>, Ok<Comment>> Get(int photoId, int commentId)
    {
        var comment = s_comments.SingleOrDefault(x => x.PhotoId == photoId && x.Id == commentId);
        if (comment is null) return TypedResults.NotFound($"Could not find comment with ID {commentId}");
        return TypedResults.Ok(comment);
    }

    public static Ok<Comment> Post(int photoId, [FromBody] Comment comment)
    {
        comment.PhotoId = photoId;
        comment.Id = s_comments.Max(x => x.Id) + 1;
        s_comments.Add(comment);
        return TypedResults.Ok(comment);
    }

    public static Results<NotFound<string>, Ok<Comment>> Put(int commentId, [FromBody] Comment comment)
    {
        var persistedComment = s_comments.SingleOrDefault(x => x.Id == comment.Id);
        if (persistedComment is null) return TypedResults.NotFound($"Could not find comment with ID {commentId}");

        persistedComment.Author = comment.Author;
        persistedComment.Message = comment.Message;
        return TypedResults.Ok(persistedComment);
    }

    public static Results<NotFound<string>, NoContent> Remove(int commentId)
    {
        var persistedComment = s_comments.SingleOrDefault(x => x.Id == commentId);
        if (persistedComment is null) return TypedResults.NotFound($"Could not find comment with ID {commentId}");

        s_comments.Remove(persistedComment);
        return TypedResults.NoContent();
    }
}