using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Online_Community.Controllers
{
    public class UserController
    {
        public static void GetPosts(int userId)
        {
            using (var context = new OnlineCommunityDbContext()) 
            {
                var user = context.Users.Include(u => u.Posts)
                                        .ThenInclude(p => p.Comments)
                                        .Include(u => u.Posts)
                                        .ThenInclude(p => p.Likes)
                                        .FirstOrDefault(u => u.UserId == userId);

                if (user == null)
                {
                    Console.WriteLine($"User with ID {userId} not found.");
                    return;
                }

                Console.WriteLine($"Posts of user {user.FullName}:");
                foreach (var post in user.Posts)
                {
                    Console.WriteLine($"Post: {post.Content}");

                    Console.WriteLine($"Comments:");
                    foreach (var comment in post.Comments)
                    {
                        Console.WriteLine($"- {comment.Content} | By: {comment.User.FullName}");
                    }

                    Console.WriteLine($"Likes:");
                    foreach (var like in post.Likes)
                    {
                        Console.WriteLine($"- By: {like.User.FullName}");
                    }
                }
            }
        }

        public static void GetFollowings(int userId)
        {
            using(var context = new OnlineCommunityDbContext())
            {
                var followings = context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Following)
                .ToList();

                Console.WriteLine($"Followings of user with ID {userId}:");
                foreach (var following in followings)
                {
                    Console.WriteLine(following.FullName);
                }
            }
        }

        public static void GetFollowers(int userId)
        {
            using (var context = new OnlineCommunityDbContext())
            {
                var followers = context.Follows
                .Where(f => f.FollowingId == userId)
                .Select(f => f.Follower)
                .ToList();

                Console.WriteLine($"Followers of user with ID {userId}:");
                foreach (var follower in followers)
                {
                    Console.WriteLine(follower.FullName);
                }
            }
        }

    }
}
