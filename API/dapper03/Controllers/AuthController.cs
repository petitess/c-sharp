using DotnetAPI2.Dtos;
using DotnetAPI2.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using DotnetAPI2.Helpers;
using DotnetAPI2.Models;
using Dapper;
using AutoMapper;

namespace DotnetAPI2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        private readonly AuthHelper _authHelper;
        private readonly ReusableSql _reusableSql;
        private readonly IMapper _mapper;
              public AuthController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
            _authHelper = new AuthHelper(config);
            _reusableSql = new ReusableSql(config);
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserForRegistrationDto, UserComplete>();
            }));
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(UserForRegistrationDto registration)
        {
            if (registration.Password == registration.PasswordConfirm) 
            {
                string sqlCheckUserExists = "SELECT Email FROM TutorialAppSchema.Auth WHERE Email = '" + registration.Email + "'";
                IEnumerable<string> existingUser = _dapper.LoadData<string>(sqlCheckUserExists);
                if (existingUser.Count() == 0) 
                {

                    UserForLoginDto userForSetPassword = new UserForLoginDto()
                    {
                        Email = registration.Email,
                        Password = registration.Password
                    };
                    if (_authHelper.SetPassword(userForSetPassword))
                    {
                        UserComplete userComplete = _mapper.Map<UserComplete>(registration);
                        userComplete.Active = true;

                        if (_reusableSql.UpsertUser(userComplete))
                        {
                            return Ok(registration);
                        }
                    }
                    throw new Exception("Failed to register user");
                }
                throw new Exception("User already exists");
            }
            throw new Exception("Passwords do not match");
        }

        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(UserForLoginDto userForSetPassword)
        {
            if (_authHelper.SetPassword(userForSetPassword))
            {
                return Ok();
            }
            throw new Exception("Failed to update password");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto login) 
        {
            string sqlForHashAndSalt = @"EXEC TutorialAppSchema.spLoginConfirmation_Get @Email = @EmailParam";

            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@EmailParam", login.Email, DbType.String);

            UserForLoginConfirmationDto userForConfirmation = _dapper
                .LoadDataSingleWithParameters<UserForLoginConfirmationDto>(sqlForHashAndSalt, sqlParameters);
            byte[] passwordHash = _authHelper.GetPasswordHash(login.Password, userForConfirmation.PasswordSalt);
            for (int index = 0; index < passwordHash.Length; index ++)
            {
                if (passwordHash[index] != userForConfirmation.PasswordHash[index])
                {
                   return StatusCode(401, "Incorrect password");
                }
            }
            string userIdSql = "SELECT UserId FROM TutorialAppSchema.Users WHERE Email = '" + login.Email + "'";
            int userId = _dapper.LoadDataSingle<int>(userIdSql);
            return Ok(new Dictionary<string, string>
                {
                    {
                        "token", _authHelper.CreateToken(userId)
                    }
                });
        }

        [HttpGet("RefreshToken")]
        public string RefreshToken()
        {
            string userIdSql = "SELECT UserId FROM TutorialAppSchema.Users WHERE UserId = '" + 
                User.FindFirst("userId")?.Value + "'";
            int userId = _dapper.LoadDataSingle<int>(userIdSql);
            return _authHelper.CreateToken(userId);
        }
    }
}
