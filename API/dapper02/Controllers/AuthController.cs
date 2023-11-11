using DotnetAPI2.Dtos;
using DotnetAPI2.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using DotnetAPI2.Helpers;

namespace DotnetAPI2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        private readonly AuthHelper _authHelper;
        public AuthController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
            _authHelper = new AuthHelper(config);
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
                    byte[] passwordSalt = new byte[128 / 8];
                    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                    {
                        rng.GetNonZeroBytes(passwordSalt);
                    }
                    /*string passwordSaltPlusString = _config.GetSection("AppSettings:PasswordKey").Value + 
                        Convert.ToBase64String(passwordSalt);*/
                    byte[] passwordHash = _authHelper.GetPasswordHash(registration.Password, passwordSalt);
                    string sqlAddAuth = @"
                            INSERT INTO TutorialAppSchema.Auth (
                            [Email],
                            [PasswordHash],
                            [PasswordSalt]
                            )VALUES('" + registration.Email + 
                            "', @PasswordHash, @PasswordSalt)";
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    SqlParameter passwordSaltParameter = new SqlParameter("@PasswordSalt", SqlDbType.VarBinary);
                    passwordSaltParameter.Value = passwordSalt;
                    SqlParameter passwordHashParameter = new SqlParameter("@PasswordHash", SqlDbType.VarBinary);
                    passwordHashParameter.Value = passwordHash;
                    sqlParameters.Add(passwordSaltParameter);
                    sqlParameters.Add(passwordHashParameter);
                    if (_dapper.ExecuteSqlWithParameters(sqlAddAuth, sqlParameters))
                    {
                        string sqlAddUser = @"INSERT INTO TutorialAppSchema.Users(
                                [FirstName],
                                [LastName],
                                [Email],
                                [Gender],
                                [Active]
                                ) VALUES ("
                                +
                                "'" + registration.FirstName +
                                "', '" + registration.LastName +
                                "', '" + registration.Email +
                                "', '" + registration.Gender +
                                        "', 1)";
                        if (_dapper.ExecuteSql(sqlAddUser))
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
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto login) 
        {
            string sqlForHashAndSalt = @"SELECT
                        [PasswordHash],
                        [PasswordSalt] FROM TutorialAppSchema.Auth WHERE Email = '" + login.Email + "'";
            UserForLoginConfirmationDto userForConfirmation = _dapper
                .LoadDataSingle<UserForLoginConfirmationDto>(sqlForHashAndSalt);
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
