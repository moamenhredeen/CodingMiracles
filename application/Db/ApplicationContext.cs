using core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Db
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=/home/moamenhraden/new-git/coding-miracles/CodingMiracles/db.sqlite"); 
        }
    }
}