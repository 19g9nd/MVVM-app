using TurboAz.Models;
using TurboAz.Repositories;

namespace TurboAz.Repositories
{
    public class UserRepository : Repository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public User GetUserByLogin(string login)
        {
            string sql = "SELECT * FROM Users WHERE Login = @Login";
            return QuerySingleOrDefault<User>(sql, new { Login = login });
        }

        public void InsertUser(User user)
        {
            string sql = "INSERT INTO Users (Login, Password) VALUES (@Login, @Password)";
            Execute(sql, user);
        }
 
    }
}
