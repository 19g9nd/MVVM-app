namespace TurboAz.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }

        public override string ToString() => $"#{Id}: {Header} {Description}";
    }
}
