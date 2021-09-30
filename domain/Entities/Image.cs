namespace core.Entities
{
    public class Image : Entity
    {   
        public string Name { get; set; }
        public string Path { get; set; }
        public long PostId { get; set; }
        public Post Post { get; set; }
    }
    
}