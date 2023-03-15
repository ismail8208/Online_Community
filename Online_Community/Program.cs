using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Online_Community.Controllers;

namespace Online_Community
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*step 1, Create Database using this method*/
            //CreateDatabase();

            /*step 2, Add Dummy Data using this method*/
            //DummyData();


            /*If you want to show the latest news, use this method*/
            PostController.LatestNews(1 /* or insert your Id */);


    /*View profile*/

            /*If you want to show a user's posts, use this method*/
            //UserController.GetPosts(1 /* or insert any user Id*/);

            /*If you want to show someone's followers, use this method*/
            //UserController.GetPosts(1 /* or insert any user Id*/);

            /*If you want to show someone's followings, use this method*/
            //UserController.GetPosts(1 /* or insert any user Id*/);
        }

        private static void CreateDatabase()
        {
            using (var contxt = new OnlineCommunityDbContext())
            {
                contxt.Database.EnsureCreated();
            }
        }

        private static void DummyData()
        {

            using (var context = new OnlineCommunityDbContext())
            {
                //Add users
                List<User> users = new List<User>();
                for (int i = 1; i <= 10; i++)
                {
                    users.Add(new User { FullName = $"User{i} " });
                }
                context.Users.AddRange(users);

                //Add Posts
                List<Post> posts = new List<Post>();
                int postNumber = 1;
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        posts.Add(new Post { UserId = i, Content = $"Post number {postNumber}" });
                        postNumber++;
                    }
                }
                context.Posts.AddRange(posts);

                //Add Comments
                List<Comment> comments = new List<Comment>();
                int commentNumber = 1;
                for (int i = 1; i <= 50; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        for (int k = 1; k <= 2; k++)
                        {
                            comments.Add(new Comment { PostId = i, UserId = j, Content = $"Comment number {commentNumber} " });
                            commentNumber++;
                        }
                    }
                }
                context.Comments.AddRange(comments);

                //Add Likes
                List<Like> Likes = new List<Like>();
                for (int i = 1; i <= 50; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        for (int k = 1; k <= 5; k++)
                        {
                            Likes.Add(new Like { PostId = i, UserId = j });
                        }
                    }
                }
                context.Likes.AddRange(Likes);

                //Follow
                List<Follow> follows = new List<Follow>()
                {
                    new Follow {FollowerId = 1, FollowingId = 2},
                    new Follow {FollowerId = 1, FollowingId = 3},
                    new Follow {FollowerId = 1, FollowingId = 4},
                    new Follow {FollowerId = 1, FollowingId = 5},
                    new Follow {FollowerId = 2, FollowingId = 1},
                    new Follow {FollowerId = 2, FollowingId = 3},
                    new Follow {FollowerId = 2, FollowingId = 4},
                    new Follow {FollowerId = 3, FollowingId = 1},
                    new Follow {FollowerId = 3, FollowingId = 2},
                    new Follow {FollowerId = 3, FollowingId = 4},
                    new Follow {FollowerId = 1, FollowingId = 4},
                    new Follow {FollowerId = 1, FollowingId = 5},
                    new Follow {FollowerId = 4, FollowingId = 6},
                    new Follow {FollowerId = 4, FollowingId = 7},
                    new Follow {FollowerId = 4, FollowingId = 8},
                    new Follow {FollowerId = 4, FollowingId = 1},
                };

                context.Follows.AddRange(follows);

                context.SaveChanges();

            }
        }
    }
}