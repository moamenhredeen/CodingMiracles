using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace core.Entities
{
    public class Comment : Entity
    {
        public string body { get; set; }
        public IEnumerable<Like> Likes { get; set; }
        
        [ForeignKey("Post")]
        public long PostId { get; set; }
        public Post Post { get; set; }
       
        // TODO : comments on comments
        
        public Comment()
        {
            Likes = new HashSet<Like>();
        }
    }
}