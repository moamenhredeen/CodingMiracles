using System;
using System.Collections.Generic;
using core.Entities;

namespace Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(long postId);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post); 
    }
}