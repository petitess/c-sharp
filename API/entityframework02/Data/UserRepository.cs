using DotnetAPI.Data;
using DotnetAPI.Models;

namespace DotnetAPI_EF.Data
{
    public class UserRepository : IUserRepository
    {
        DataContextEF _entityFramework;
        public UserRepository(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);
        }
        public bool SaveChanges()
        {
            return _entityFramework.SaveChanges() > 0;
        }
        public void AddEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Add(entityToAdd);
            }
        }
        public void RemoveEntity<T>(T entityToRemove)
        {
            if (entityToRemove != null)
            {
                _entityFramework.Remove(entityToRemove);
            }
        }
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _entityFramework.Users.ToList<User>();
            return users;
        }
        public User GetSingleUser(int userId)
        {
            User? user = _entityFramework.Users
                .Where(u => u.UserId == userId)
                .FirstOrDefault<User>();
            if (user != null)
            {
                return user;
            }
            throw new Exception("Failed to get user");
        }
        public IEnumerable<UserJobInfo> GetJobInfo()
        {
            IEnumerable<UserJobInfo> users = _entityFramework.UserJobInfo.ToList<UserJobInfo>();
            return users;
        }
        public UserJobInfo GetSingleJobInfo(int userId)
        {
            UserJobInfo? userX = _entityFramework.UserJobInfo
                .Where(u => u.UserId == userId)
                .FirstOrDefault<UserJobInfo>();
            if (userX != null)
            {
                return userX;
            }
            throw new Exception("Failed to get job info");
        }
        public IEnumerable<UserSalary> GetSalary()
        {
            IEnumerable<UserSalary> users = _entityFramework.UserSalary.ToList<UserSalary>();
            return users;
        }
        public UserSalary GetSingleSalary(int userId)
        {
            UserSalary? userX = _entityFramework.UserSalary
                .Where(u => u.UserId == userId)
                .FirstOrDefault<UserSalary>();
            if (userX != null)
            {
                return userX;
            }
            throw new Exception("Failed to get user salary");
        }
    }
}
