using core.Constants;

namespace core.Entities
{
    public class Like : Entity
    {
        public LikeType LikeType { get; set; }
        
        public long CommentId { get; set; }
        public long PostId { get; set; }
        
        public Comment Comment { get; set; }
        public Post Post { get; set; }
    }
}