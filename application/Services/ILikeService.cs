using System.Collections.Generic;
using core.Constants;
using core.Entities;

namespace Services
{
    public interface ILikeService
    {
        IEnumerable<Like> GetAllLikesOnPost(long postId); 
        IEnumerable<Like> GetAllLikesOnComment(long commentId); 
        void AddLike(LikeType type);
        void UpdateLike(Like like);
        void DeleteLikeById(long id); 
    }
}