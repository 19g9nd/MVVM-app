using TurboAz.Models;
using TurboAz.Repositories;

namespace TurboAz.ViewModels
{
    public class CreatePostView 
    {
        private readonly PostRepository postRepository;

        public CreatePostView(string connectionString)
        {
            postRepository = new PostRepository(connectionString);
        }

        public void CreatePost(string header, string description)
        {
            Post post = new Post { Header = header, Description = description };
            postRepository.InsertPost(post);
        }
    }
}
