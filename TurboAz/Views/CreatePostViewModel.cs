using TurboAz.Models;
using TurboAz.Repositories;

namespace TurboAz.ViewModels
{
    public class CreatePostViewModel 
    {
        private readonly PostRepository postRepository;

        public CreatePostViewModel(string connectionString)
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
