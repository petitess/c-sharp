using AutoMapper;
using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserEFController : ControllerBase
    {
        DataContextEF _entityFramework;
        IMapper _mapper;

        public UserEFController(IConfiguration config) {
            _entityFramework = new DataContextEF(config);
            //Create Autommapper
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserToAddDto, User>();
                cfg.CreateMap<UserSalary, UserSalary>();
                cfg.CreateMap<UserJobInfo, UserJobInfo>();
            }));
        }
        //THis is an endpoint
        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable <User> users = _entityFramework.Users.ToList<User>();
            return users;
        }

        [HttpGet("GetSingleUser/{userId}")]
        public User GetSingleUser(int userId)
        {
            User? user = _entityFramework.Users
                .Where(u => u.UserId == userId)
                .FirstOrDefault<User>();
            if (user != null)
            {
                return user;
            }
            throw new Exception("Failed to gt user");
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser(User user)
        {
            User? userDb = _entityFramework.Users
                .Where(u => u.UserId == user.UserId)
                .FirstOrDefault<User>();
            if (userDb != null)
            {
                userDb.FirstName = user.FirstName;
                userDb.LastName = user.LastName;
                userDb.Email = user.Email;
                userDb.Gender = user.Gender;
                userDb.Active = user.Active;
                if (_entityFramework.SaveChanges() > 0)
                {
                    return Ok();
                }
            }

            throw new Exception("Failed to update user");
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserToAddDto user)
        {   //Use Automapper
            User userDb = _mapper.Map<User>(user);

            _entityFramework.Add(userDb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }

            throw new Exception("Failed to add user");
        }

        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId) 
        {
            User? userDb = _entityFramework.Users
                .Where(u => u.UserId == userId)
                .FirstOrDefault<User>();
            
            if (userDb != null)
            {
                _entityFramework.Users.Remove(userDb);
                if (_entityFramework.SaveChanges() > 0)
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete user");
        }

        [HttpGet("GetJobInfo/{userId}")]
        public IEnumerable<UserJobInfo> GetJobInfo(int userId)
        {
                return _entityFramework.UserJobInfo
                .Where(u => u.UserId == userId)
                .ToList();

        }

        [HttpPost("AddNewJobInfo")]
        public IActionResult AddNewJobInfo(UserJobInfo user)
        {   
            _entityFramework.UserJobInfo.Add(user);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }

            throw new Exception("Failed to add job info");
        }
        
        [HttpPut("EditJobInfo")]
        public IActionResult EditJobInfo(UserJobInfo user)
        {
            UserJobInfo? info = _entityFramework.UserJobInfo
                .Where(u => u.UserId == user.UserId)
                .FirstOrDefault<UserJobInfo>();
            if (info != null)
            {
               _mapper.Map(user, info);
                if (_entityFramework.SaveChanges() > 0)
                {
                    return Ok();
                }
                throw new Exception("Failed to update job info");
            }
            throw new Exception("Failed to find job info");
        }

        [HttpGet("GetSingleSalary/{userId}")]
        public IEnumerable<UserSalary> GetSingleSalary(int userId)
        {
                return _entityFramework.UserSalary
                .Where(u => u.UserId == userId)
                .ToList();
        }

        [HttpPost("AddUserSalary")]
        public IActionResult AddUserSalary(UserSalary user)
        {   
            _entityFramework.UserSalary.Add(user);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }

            throw new Exception("Failed to add salary");
        }
        [HttpPut("UpdateSalary")]
        public IActionResult UpdateSalary(UserSalary user)
        {
            UserSalary? userToUpdate = _entityFramework.UserSalary
                .Where(u =>u.UserId == user.UserId)
                .FirstOrDefault();
            if(userToUpdate != null)
            {
                _mapper.Map(user, userToUpdate);
                if(_entityFramework.SaveChanges() > 0) 
                { 
                    return Ok(); 
                }
                throw new Exception("Updating salary failed on save");
            }
            throw new Exception("Failed ti find salary to update");
        }

        [HttpDelete("DeleteSalary/{userId}")]
        public IActionResult DeleteSalary(int userId)
        {
            UserSalary? salary = _entityFramework.UserSalary
                .Where(u => u.UserId == userId)
                .FirstOrDefault();

            if (salary != null)
            {
                _entityFramework.UserSalary.Remove(salary);

                if (_entityFramework.SaveChanges() > 0)
                {
                    return Ok();
                }
                throw new Exception("Deleting salary failed on save");
            }
            throw new Exception("Failed to find salary to delete");
        }
    }
}