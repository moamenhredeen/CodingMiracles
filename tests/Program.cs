using System;
using core.Constants;
using core.Entities;
using Services.Db;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("programm starts ...");
            var context = new ApplicationContext();
            // var post = new Post()
            // {
            //     Id = 0,
            //     header = "header", body = "body"
            // };
            var comment = new Comment(){Id = 0, body = "something", PostId = 1};
            var like = new Like() {Id = 0, LikeType = LikeType.LIKE, PostId = 1}; 
            context.Add(comment);
            context.Add(like);
            context.SaveChanges(); 
        }
    }
}