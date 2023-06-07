using TurboAz.Models;

namespace TurboAz.Repositories
{
    public class PostRepository : Repository
    {
        public PostRepository(string connectionString) : base(connectionString)
        {
        }

        public void InsertPost(Post post)
        {
            string sql = "INSERT INTO Posts (Header, Description) VALUES (@Header, @Description)";
            Execute(sql, post);
        }

        public Post GetPostById(int id)
        {
            string sql = "SELECT * FROM Posts WHERE Id = @Id";
            return QuerySingleOrDefault<Post>(sql, new { Id = id });
        }

        public void DeletePost(int id)
        {
            string sql = "DELETE FROM Posts WHERE Id = @Id";
            Execute(sql, new { Id = id });
        }

        public void UpdatePost(Post post)
        {
            string sql = "UPDATE Posts SET Header = @Header, Description = @Description WHERE Id = @Id";
            Execute(sql, post);
        }

        // Additional methods for fetching multiple posts
    }
}
