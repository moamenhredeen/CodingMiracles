using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArabCoders.Data;
using ArabCoders.Models;
using ArabCoders.SecondLayerOfModels;
using Like = ArabCoders.Models.Like;

namespace ArabCoders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly DataContext _context;

        FormatData json = new FormatData();
        public LikesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [HttpGet("Posts")]
        public async Task<FormatData> GetLikePosts()
        {
            var likes = _context.Likes.Where(c => c.postId != null).Select(l => new {
                id = l.id, userName = l.user.first_name +" "+l.user.last_name,
                postId = l.postId 
            }).ToList();

            json.data = likes;
            json.massage = "The request was successful";
            return json;
        }
        [HttpGet("Comments")]
        public async Task<FormatData> GetLikeComments()
        {
            var comments = _context.Likes.Where(c => c.commentId != null).Select(l => new
            {
                id = l.id,
                userName = l.user.first_name + " " + l.user.last_name,
                CommentId = l.commentId
            }).ToList();

            json.data = comments;
            json.massage = "The request was successful";
            return json;
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<FormatData> GetLike(int id)
        {
            var like = getLike(id);

            if (like == null)
            {
                json.massage = "this the user not found";
                return json;
            }
            json.massage = "The request was successful";
            json.data = like;
            return json;
        }

        // PUT: api/Likes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<FormatData> PutLike(int id, LikeSecond newlike)
        {

            Like like = updateLike(id, newlike);
            

            if (like != null)
            {
                _context.Entry(like).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    json.massage = "The request was successful";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    json.massage = ex.Message.ToString();
                    return json;
                    //if (!LikeExists(id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
            else
            {
                json.massage = "the user not found";
            }
            
            return json;
        }

        // POST: api/Likes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<FormatData> PostLike(LikeSecond newlike)
        {
            Like like = setValueToLike(newlike);  
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
            json.massage = "The request was successful";
            json.data = new { id = like.id };
            return json;
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        public async Task<FormatData> DeleteLike(int id)
        {
            var like = await _context.Likes.FindAsync(id);
            if (like == null)
            {
                json.massage = "this the user not found";
                return json;
            }

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
            json.massage = "User deleted";
            return json;
        }

        private bool LikeExists(int id)
        {
            return _context.Likes.Any(e => e.id == id);
        }

        private Like setValueToLike(LikeSecond newlike)
        {
            int likeTypeFk = getLikeTypeId(newlike.name);
            Like like = new Like
            {
                likeTypeID = likeTypeFk,
                commentId = newlike.commentId,
                postId = newlike.postId,
                userId = newlike.userId
            };
            return like;
        }

        private Like updateLike(int id, LikeSecond newLike)
        {
            Like like = getLike(id);
                if(like != null)
            {
                int LikeTypeFK = getLikeTypeId(newLike.name);
                like.postId = newLike.postId;
                like.commentId = newLike.commentId;
                like.likeTypeID = LikeTypeFK;
                like.userId = newLike.userId;
            }
            return like;
        }

        private int  getLikeTypeId(string likeName)
        {
            var obj = _context.Like_types.SingleOrDefault(l => l.name.Equals(likeName));

            return obj.id;
        }

        private Like getLike(int id)
        {
            var like =  _context.Likes.SingleOrDefault(l => l.id == id);
            return like;
        }
    }
}
