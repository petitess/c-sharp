using DotnetAPI2.Data;
using DotnetAPI2.Dtos;
using DotnetAPI2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        public PostController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("GetPost")]
        public IEnumerable<Post> GetPost()
        {
            string sql = @"SELECT [PostId],
                            [UserId],
                            [PostTitle],
                            [PostContent],
                            [PostCreated],
                            [PostUpdated] FROM TutorialAppSchema.Posts";
            return _dapper.LoadData<Post>(sql);
        }

        [HttpGet("GetSinglePost/{PostId}")]
        public Post GetSinglePost(int postId)
        {
            string sql = @"SELECT [postId],
                            [UserId],
                            [PostTitle],
                            [PostContent],
                            [PostCreated],
                            [PostUpdated] FROM TutorialAppSchema.Posts
                                WHERE PostId = " + postId;
            return _dapper.LoadDataSingle<Post>(sql);
        }

        [HttpGet("GetPostByUser/{userId}")]
        public IEnumerable<Post> GetPostByUser(int userId)
        {
            string sql = @"SELECT [PostId],
                            [UserId],
                            [PostTitle],
                            [PostContent],
                            [PostCreated],
                            [PostUpdated] FROM TutorialAppSchema.Posts
                                WHERE PostId = " + userId;
            return _dapper.LoadData<Post>(sql);
        }

        [HttpGet("GetMyPosts")]
        public IEnumerable<Post> GetMyPosts()
        {
            string sql = @"SELECT [PostId],
                            [UserId],
                            [PostTitle],
                            [PostContent],
                            [PostCreated],
                            [PostUpdated] FROM TutorialAppSchema.Posts
                                WHERE UserId = " + this.User.FindFirst("userId")?.Value;
            return _dapper.LoadData<Post>(sql);
        }

        [HttpGet("PostBySearch/{searchParam}")]
        public IEnumerable<Post> PostBySearch(string searchParam)
        {
            string sql = @"SELECT [PostId],
                            [UserId],
                            [PostTitle],
                            [PostContent],
                            [PostCreated],
                            [PostUpdated] FROM TutorialAppSchema.Posts
                        WHERE PostTitle LIKE '%" + searchParam + "%'" +
                        " OR PostContent LIKE '%" + searchParam + "%'";
            return _dapper.LoadData<Post>(sql);
        }

        [HttpPost("AddPost")]
        public IActionResult AddPost(PostToAddDto postToAdd)
        {
            string sql = @"INSERT INTO TutorialAppSchema.Posts(
                    [UserId],
                    [PostTitle],
                    [PostContent],
                    [PostCreated],
                    [PostUpdated]
                    ) VALUES (" + this.User.FindFirst("userId")?.Value +
                    ",'" + postToAdd.PostTitle + 
                    "','" + postToAdd.PostContent +
                    "', GETDATE(), GETDATE())";
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to create post");
        }

        [HttpPut("EditPost")]
        public IActionResult EditPost(PostToEditDto postToEdit)
        {
            string sql = @"UPDATE TutorialAppSchema.Posts 
                    SET PostTitle = '" + postToEdit.PostTitle +
                    "', PostContent = '" + postToEdit.PostContent +
                    @"', PostUpdated = GETDATE()
                        WHERE PostId = " + postToEdit.PostId.ToString() +
                        "AND UserId = " + this.User.FindFirst("userId")?.Value;
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to edit post");
        }

        [HttpDelete("DeletePost/{postId}")]
        public IActionResult DeletePost(int postId) 
        {
            string sql = "DELETE FROM TutorialAppSchema.Posts WHERE PostId = " + postId.ToString() +
                        "AND UserId = " + this.User.FindFirst("userId")?.Value; ;
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to delete post");
        }
    }
}
