using DotnetAPI2.Data;
using DotnetAPI2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        DataContextDapper _dapper;
        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            string sql = @"
           SELECT [UserId],
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active] FROM TutorialAppSchema.Users     
            ";
            IEnumerable<User> users = _dapper.LoadData<User>(sql);
            return users;
        }
        [HttpGet("GetSingleUser/{UserId}")]
        public User GetSingleUser(int UserId)
        {
            string sql = @"SELECT [UserId],
                        [FirstName],
                        [LastName],
                        [Email],
                        [Gender],
                        [Active] FROM TutorialAppSchema.Users
                        WHERE UserId = " + UserId.ToString();
            User user = _dapper.LoadDataSingle<User>(sql);
            return user;
        }

        [HttpPut("EditUser")]
        public User EditUser(User user)
        {
            string sql = @"
                        UPDATE TutorialAppSchema.Users
                        SET 
                        [FirstName] = '" + user.FirstName + 
                        "', [LastName] = '" + user.LastName + 
                        "', [Email] = '" + user.LastName +
                        "', [Gender] = '" + user.Gender + 
                        "', [Active] = '" + user.Active + 
                        "' WHERE UserId = " + +user.UserId;
            if (_dapper.ExecuteSql(sql))
            {
                return user;
            }
            throw new Exception("Failed to update user");
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserToAddDto user)
        {
            string sql = @"INSERT INTO TutorialAppSchema.Users(
                                [FirstName],
                                [LastName],
                                [Email],
                                [Gender],
                                [Active]
                                ) VALUES (" + 
                                "'" + user.FirstName + 
                                "', '" + user.LastName + 
                                "', '" + user.Email +
                                "', '" + user.Gender +
                                "', '" + user.Active +
                                "')";
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to update user");
        }

        [HttpDelete("DeleteUser/{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            string sql = @"DELETE FROM TutorialAppSchema.Users
                            WHERE UserId =" + UserId.ToString();
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to delete user");
        }

        [HttpGet("GetSalary")]
        public IEnumerable<UserSalary> GetSalary()
        {
            string sql = @"
           SELECT [UserId],
            [Salary],
            [AvgSalary] FROM TutorialAppSchema.UserSalary   
            ";
            IEnumerable<UserSalary> users = _dapper.LoadData<UserSalary>(sql);
            return users;
        }

        [HttpPut("EditSalary")]
        public UserSalary EditSalary(UserSalary salaryForUpdate)
        {
            string sql = @"
                        UPDATE TutorialAppSchema.UserSalary
                        SET 
                        Salary = " + salaryForUpdate.Salary +
                        ", AvgSalary = " + salaryForUpdate.AvgSalary +
                        " WHERE UserId = " + +salaryForUpdate.UserId;
            if (_dapper.ExecuteSql(sql))
            {
                return salaryForUpdate;
            }
            throw new Exception("Failed to update user salary");
        }

        [HttpPost("AddNewSalary")]
        public IActionResult AddNewSalary(UserSalary salaryToInsert)
        {
            string sql = @"INSERT INTO TutorialAppSchema.UserSalary(
                                UserId,
                                Salary
                                ) VALUES (" + salaryToInsert.UserId
                                + ", "+ salaryToInsert.Salary
                                + ")";
            if (_dapper.ExecuteSql(sql))
            {
                return Ok(salaryToInsert);
            }
            throw new Exception("Failed to update user");
        }

        [HttpGet("GetJobInfo")]
        public IEnumerable<UserSalary> GetJobInfo()
        {
            string sql = @"
           SELECT [UserId],
            [JobTitle],
            [Department] FROM TutorialAppSchema.UserJobInfo
            ";
            IEnumerable<UserSalary> users = _dapper.LoadData<UserSalary>(sql);
            return users;
        }

        [HttpGet("GetSalary/{UserId}")]
        public IEnumerable<UserSalary> GetSalary(int UserId)
        {
            return _dapper.LoadData<UserSalary>(@"SELECT UserSalary.UserId,
                        UserSalary.Salary,
                        UserSalary.AvgSalary 
                        FROM TutorialAppSchema.UserSalary
                        WHERE UserId = " + UserId);
        }
    }
}