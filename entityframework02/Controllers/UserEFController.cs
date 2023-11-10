using AutoMapper;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using DotnetAPI_EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserEFController : ControllerBase
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public UserEFController(IConfiguration config, IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
        public IEnumerable<User> GetUsers(bool OrderByDescending)
        {
            if (OrderByDescending)
            {
                IEnumerable<User> users = _userRepository.GetUsers().OrderByDescending(u => u.UserId);
                return users;
            }
            else
            {
                IEnumerable<User> users = _userRepository.GetUsers();
                return users;
            }
        }

        [HttpGet("GetSingleUser/{userId}")]
        public User GetSingleUser(int userId)
        {
           return _userRepository.GetSingleUser(userId);
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser(User user)
        {
            User? userDb = _userRepository.GetSingleUser(user.UserId);
            if (userDb != null)
            {
                userDb.FirstName = user.FirstName;
                userDb.LastName = user.LastName;
                userDb.Email = user.Email;
                userDb.Gender = user.Gender;
                userDb.Active = user.Active;
                if (_userRepository.SaveChanges())
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
            _userRepository.AddEntity(userDb);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to add user");
        }

        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            User? userDb = _userRepository.GetSingleUser(userId);

            if (userDb != null)
            {
                _userRepository.RemoveEntity(userDb);
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete user");
        }

        [HttpGet("GetJobInfo")]
        public IEnumerable<UserJobInfo> GetJobInfo(bool OrderByDescending)
        {
            if (OrderByDescending)
            {
                IEnumerable<UserJobInfo> users = _userRepository.GetJobInfo().OrderByDescending(u => u.UserId);
                return users;
            }
            else
            {
                IEnumerable<UserJobInfo> users = _userRepository.GetJobInfo();
                return users;
            }
        }

        [HttpGet("GetSingleJobInfo/{userId}")]
        public UserJobInfo GetSingleJobInfo(int userId)
        {
            return _userRepository.GetSingleJobInfo(userId);
        }

        [HttpPost("AddNewJobInfo")]
        public IActionResult AddNewJobInfo(UserJobInfo user)
        {
            _userRepository.AddEntity(user);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to add job info");
        }

        [HttpPut("EditJobInfo")]
        public IActionResult EditJobInfo(UserJobInfo user)
        {
            UserJobInfo? info = _userRepository.GetSingleJobInfo((int)user.UserId);
            if (info != null)
            {
                _mapper.Map(user, info);
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
                throw new Exception("Failed to update job info");
            }
            throw new Exception("Failed to find job info");
        }

        [HttpGet("GetSalary")]
        public IEnumerable<UserSalary> GetSalary(bool OrderByDescending)
        {
            if (OrderByDescending)
            {
                IEnumerable<UserSalary> users = _userRepository.GetSalary().OrderByDescending(u => u.UserId);
                return users;
            }
            else
            {
                IEnumerable<UserSalary> users = _userRepository.GetSalary();
                return users;
            }
        }

        [HttpGet("GetSingleSalary/{userId}")]
        public UserSalary GetSingleSalary(int userId)
        {
            return _userRepository.GetSingleSalary(userId);
        }

        [HttpPost("AddUserSalary")]
        public IActionResult AddUserSalary(UserSalary user)
        {
            _userRepository.AddEntity(user);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to add salary");
        }
        [HttpPut("UpdateSalary")]
        public IActionResult UpdateSalary(UserSalary user)
        {
            UserSalary? userToUpdate = _userRepository.GetSingleSalary((int)user.UserId);
            if (userToUpdate != null)
            {
                _mapper.Map(user, userToUpdate);
                if (_userRepository.SaveChanges())
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
            UserSalary? salary = _userRepository.GetSingleSalary(userId);

            if (salary != null)
            {
                _userRepository.RemoveEntity(salary);
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
                throw new Exception("Deleting salary failed on save");
            }
            throw new Exception("Failed to find salary to delete");
        }
    }
}