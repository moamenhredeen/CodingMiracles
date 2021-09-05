using System.Collections.Generic;
using core.Entities;

namespace Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllCommentsOnPost(long postId); 
        IEnumerable<Comment> GetAllReplyOnComments(long commentId); 
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteCommentById(long id); 
    }
}
