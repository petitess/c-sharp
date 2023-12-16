using Dapper;
using DotnetAPI2.Data;
using DotnetAPI2.Dtos;
using DotnetAPI2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [HttpGet("GetPost/{postId}/{userId}/{searchParam}")]
        public IEnumerable<Post> GetPost(int postId = 0, int userId = 0, string searchParam = "None")
        {
            string sql = @"EXEC TutorialAppSchema.spPosts_Get";
            string stringParameter = "";

            DynamicParameters sqlParameter = new DynamicParameters();
            if(postId != 0) 
            {
                stringParameter += ", @PostId=@PostIdParameter";
                sqlParameter.Add("@PostIdParameter", postId, DbType.Int32);
            }
            if (userId != 0)
            {
                stringParameter += ", @UserId=@UserIdParameter";
                sqlParameter.Add("@UserIdParameter", postId, DbType.Int32);
            }
            if(searchParam.ToLower() != "none") 
            {
                stringParameter += ", @SearchValue=@SearchValueParameter";
                sqlParameter.Add("@SearchValueParameter", searchParam, DbType.String);
            }
            if (stringParameter.Length > 0)
            {
                sql += stringParameter.Substring(1);
            }
            return _dapper.LoadDataWithParameters<Post>(sql, sqlParameter);
        }

        [HttpGet("GetMyPosts")]
        public IEnumerable<Post> GetMyPosts()
        {
            string sql = @"EXEC TutorialAppSchema.spPosts_Get @UserId=@UserIdParameter";
            DynamicParameters sqlParameter = new DynamicParameters();
            sqlParameter.Add("@UserIdParameter", this.User.FindFirst("userId")?.Value, DbType.Int32);

            return _dapper.LoadDataWithParameters<Post>(sql, sqlParameter);
        }

        [HttpPut("UpsertPost")]
        public IActionResult UpsertPost(Post postToUpsert)
        {
            string sql = @"EXEC TutorialAppSchema.spPost_Upsert
                    @UserId =@UserIdParameter,
                    @PostTitle = @PostTitleParameter,
                    @PostContent = @PostContentParameter";

            DynamicParameters sqlParameter = new DynamicParameters();
            sqlParameter.Add("@UserIdParameter", this.User.FindFirst("userId")?.Value, DbType.Int32);
            sqlParameter.Add("@PostTitleParameter", postToUpsert.PostTitle, DbType.String);
            sqlParameter.Add("@PostContentParameter", postToUpsert.PostContent, DbType.String);

            if (postToUpsert.PostId > 0)
            {
                sql += ", @PostId = @PostTitleParameter";
                sqlParameter.Add("@PostTitleParameter", postToUpsert.PostId, DbType.Int32);
            }
            if (_dapper.ExecuteSqlWithParameters(sql, sqlParameter))
            {
                return Ok();
            }
            throw new Exception("Failed to create post");
        }

        [HttpDelete("DeletePost/{postId}")]
        public IActionResult DeletePost(int postId) 
        {
            string sql = @"EXEC TutorialAppSchema.spPost_Delete 
                        @PostId = @PostIdParameter,
                        @UserId = @UserIdParameter";

            DynamicParameters sqlParameter = new DynamicParameters();
            sqlParameter.Add("@UserIdParameter", this.User.FindFirst("userId")?.Value, DbType.Int32);
            sqlParameter.Add("@PostIdParameter", postId, DbType.Int32);

            if (_dapper.ExecuteSqlWithParameters(sql, sqlParameter))
            {
                return Ok();
            }
            throw new Exception("Failed to delete post");
        }
    }
}
