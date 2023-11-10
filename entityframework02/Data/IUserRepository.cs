using DotnetAPI.Models;

namespace DotnetAPI_EF.Data
{
    public interface IUserRepository
    {
        public bool SaveChanges();
        public void AddEntity<T>(T entityToAdd);
        public void RemoveEntity<T>(T entityToRemove);
        public IEnumerable<User> GetUsers();
        public User GetSingleUser(int userId);
        public IEnumerable<UserJobInfo> GetJobInfo();
        public UserJobInfo GetSingleJobInfo(int userId);
        public IEnumerable<UserSalary> GetSalary();
        public UserSalary GetSingleSalary(int userId);
    }
}