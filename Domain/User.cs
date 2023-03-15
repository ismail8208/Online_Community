namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public List<Post> Posts { get; set; }
        public List<Follow> Followers { get; set; }
        public List<Follow> Followings { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
