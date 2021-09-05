using System.Collections.Generic;
using System.Linq;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Db;

namespace Services
{
    public class PostService : IPostService
    {

        private ApplicationContext _db; 

        public PostService(ApplicationContext _db)
        {
            this._db = _db; 
        }
        
        public IEnumerable<Post> GetAllPosts()
        {
            return _db.Posts.ToList(); 
        }

        public Post GetPostById(long postId)
        {
            return _db.Posts.Where(el => el.Id == postId).First(); 
        }

        public void AddPost(Post post)
        {
            _db.Add(post);
            _db.SaveChanges(); 
        }

        public void UpdatePost(Post post)
        {
            _db.Update(post);
            _db.SaveChanges(); 
        }

        public void DeletePost(Post post)
        {
            _db.Remove(post);
            _db.SaveChanges();
        }
    }
}