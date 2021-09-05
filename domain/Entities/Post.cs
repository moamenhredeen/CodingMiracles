using System.Collections.Generic;

namespace core.Entities
{
    public class Post : Entity
    {
        public string header { get; set; }
        public string body { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Like> Likes { get; set; }
    }
}