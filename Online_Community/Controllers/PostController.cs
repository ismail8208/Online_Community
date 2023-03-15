using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Online_Community.Controllers
{
    public class PostController
    {
        public static void LatestNews(int userId) 
        {
            using (var context = new OnlineCommunityDbContext())
            {
                var latestPosts = context.Posts
                                .Where(p => context.Follows.Any(f => f.FollowerId == userId && f.FollowingId == p.UserId))
                                .Include(p => p.User)
                                .Include(p => p.Likes)
                                .Include(p => p.Comments)
                                .ThenInclude(c => c.User)
                                .ToList();

                foreach (var post in latestPosts)
                {
                    Console.WriteLine($"Post: {post.Content}");
                    Console.WriteLine($"Author: {post.User.FullName}");

                    if (post.Likes.Any())
                    {
                        var likesCount = post.Likes.Count;
                        var lastThreeLikes = post.Likes.Take(3);

                        Console.WriteLine($"Likes ({likesCount}):");
                        foreach (var like in lastThreeLikes)
                        {
                            Console.WriteLine($"\t{like.User.FullName}");
                        }
                    }

                    if (post.Comments.Any())
                    {
                        var commentsCount = post.Comments.Count;
                        var lastThreeComments = post.Comments.Take(3);

                        Console.WriteLine($"Comments ({commentsCount}):");
                        foreach (var comment in lastThreeComments)
                        {
                            Console.WriteLine($"\t{comment.User.FullName}: {comment.Content} ");
                        }
                    }

                    Console.WriteLine();

                }
            }
        }

    }
}
