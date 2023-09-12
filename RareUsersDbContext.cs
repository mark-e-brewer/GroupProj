using GroupProj.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupProj

{
    public class RareUsersDbContext : DbContext
    {
        public DbSet<RareUsers> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<UserTypeChangeRequests> UserTypeChangeRequests { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Categories> Categories { get; set; }



        public RareUsersDbContext(DbContextOptions<RareUsersDbContext> context) : base(context){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RareUsers>().HasData(new RareUsers[]
            {
                new RareUsers
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "BobberSon",
                    Bio = "This a bio",
                    ProfileImageURL = "This is a url",
                    Email = "this@email.com",
                    CreatedOn = DateTime.Now,
                    Active = true,
                    IsStaff = true,
                    UID = "",
                },
                new RareUsers
                {
                    Id = 2,
                    FirstName = "Sandra",
                    LastName = "BobberSon",
                    Bio = "This a bio",
                    ProfileImageURL = "This is a url",
                    Email = "this@email.com",
                    CreatedOn = DateTime.Now,
                    Active = true,
                    IsStaff = true,
                    UID = "",
                },
                new RareUsers
                {
                    Id = 3,
                    FirstName = "Tim",
                    LastName = "Timmerson",
                    Bio = "This a bio",
                    ProfileImageURL = "This is a url",
                    Email = "this@email.com",
                    CreatedOn = DateTime.Now,
                    Active = true,
                    IsStaff = false,
                    UID = "",
                }
 
            });
            modelBuilder.Entity<Comments>().HasData(new Comments[]
            {
                new Comments
                { Id = 1,
                  RareUsersId = 1,
                  PostsId = 1,
                  Content = "this is content",
                  CreatedOn= DateTime.Now,
                }
            });
            modelBuilder.Entity<Reaction>().HasData(new Reaction[]
            {
                new Reaction
                {
                    Id = 1,
                    Label = "this a label",
                    ImageURL = "A url",
                    RareUsersId = 1,
                }
            });
            modelBuilder.Entity<Subscriptions>().HasData(new Subscriptions[]
            {
                new Subscriptions
                {
                    Id = 1,
                    FollowerId = 2,
                    AuthorId = 1,
                    CreatedOn = DateTime.Now,
                    EndedOn = DateTime.Now,
                }
            });
            modelBuilder.Entity<Tags>().HasData(new Tags[]
            {
                new Tags
                { Id = 1,
                  Label = "Tag Label"
                }
            });
            modelBuilder.Entity<UserTypeChangeRequests>().HasData(new UserTypeChangeRequests[]
            {
                new UserTypeChangeRequests { Id = 1, Action = " Action", AdminOneId = 1, AdminTwoId = 2, ModifiedUserId = 3,}
            });
            modelBuilder.Entity<Posts>().HasData(new Posts[]
            {
                new Posts
                {
                    Id= 1,
                    RareUsersId = 1,
                    CategoriesId = 1,
                    PublicationDate = DateTime.Now,
                    ImageURL = "Post Image Url",
                    Content = "Blah Blah Blah",
                    Approved = true
                }
            });
            modelBuilder.Entity<Categories>().HasData(new Categories[]
            {
                new Categories { Id = 1, Label = "Comedy"}
            });
        }
    }
}
