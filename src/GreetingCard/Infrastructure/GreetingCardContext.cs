using GreetingCard.Entities;
using GreetingCard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GreetingCard.Infrastructure
{
    public class GreetingCardContext : IdentityDbContext<ApplicationUser>
    {
       
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        public GreetingCardContext(DbContextOptions options) : base(options)
        {

        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {

//            foreach (var entity in modelBuilder.Model.GetEntityTypes())
//            {
//                entity.Relational().TableName = entity.DisplayName();
//            }

//            //Card
//            #region Card
//            //modelBuilder.Entity<Card>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
//            modelBuilder.Entity<Card>().Property(x => x.CateId).IsRequired();
//            modelBuilder.Entity<Card>().Property(x => x.UserId).IsRequired();
//            modelBuilder.Entity<Card>().Property(x => x.Title).IsRequired().HasMaxLength(250);
//            modelBuilder.Entity<Card>().Property(x => x.Content).HasMaxLength(500);
//            modelBuilder.Entity<Card>().Property(x => x.ViewNo).IsRequired();
//            modelBuilder.Entity<Card>().Property(x => x.LikesNo).IsRequired();
//            modelBuilder.Entity<Card>().Property(x => x.CardSize).HasMaxLength(50);
//            modelBuilder.Entity<Card>().Property(x => x.CardType).HasMaxLength(50);
//            modelBuilder.Entity<Card>().Property(x => x.IsDeleted).IsRequired();
//            modelBuilder.Entity<Card>().Property(x => x.ImageUrl).HasMaxLength(250);
//            modelBuilder.Entity<Card>().Property(x => x.RateNo);
//            modelBuilder.Entity<Card>().Property(x => x.DateCreated).IsRequired();
//            modelBuilder.Entity<Card>().Property(x => x.IsPublished).IsRequired();
//            modelBuilder.Entity<Card>().Property(x => x.TextSearch).HasMaxLength(250);
//            #endregion
//            // Blog
//            #region BLog
//            //modelBuilder.Entity<Blog>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
//            modelBuilder.Entity<Blog>().Property(x => x.CateBlogId).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.Title).HasMaxLength(250);
//            modelBuilder.Entity<Blog>().Property(x => x.UserId).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.UrlSlug).HasMaxLength(250);
//            modelBuilder.Entity<Blog>().Property(x => x.Summary).IsRequired().HasMaxLength(300);
//            modelBuilder.Entity<Blog>().Property(x => x.Content).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.ImageUrl).HasMaxLength(500);
//            modelBuilder.Entity<Blog>().Property(x => x.ViewNo).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.IsDeleted).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.IsLocked).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.Status).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.DatePosted).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.LikeNo).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.DateEdited).IsRequired();
//            modelBuilder.Entity<Blog>().Property(x => x.TextSearch).HasMaxLength(250);
//            modelBuilder.Entity<Blog>().HasMany(x => x.Comments).WithOne(x => x.Blog);
//            #endregion
//            //Comment
//            #region Comment

//            //modelBuilder.Entity<Comment>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
//            modelBuilder.Entity<Comment>().Property(x => x.Content);
//            modelBuilder.Entity<Comment>().Property(x => x.IsDeleted).IsRequired();
//            modelBuilder.Entity<Comment>().Property(x => x.LikeNo);
//            modelBuilder.Entity<Comment>().Property(x => x.Status).IsRequired();
//            modelBuilder.Entity<Comment>().Property(x => x.CardId);
//            modelBuilder.Entity<Comment>().Property(x => x.DatePosted).IsRequired();
//            #endregion
//            //Contact
//            #region Contact
//            //modelBuilder.Entity<Contact>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
//            modelBuilder.Entity<Contact>().Property(x => x.Title).HasMaxLength(150);
//            modelBuilder.Entity<Contact>().Property(x => x.Content);
//            modelBuilder.Entity<Contact>().Property(x => x.Name).HasMaxLength(50);
//            modelBuilder.Entity<Contact>().Property(x => x.Email).HasMaxLength(100);
//            modelBuilder.Entity<Contact>().Property(x => x.Phone).HasMaxLength(20);
//            modelBuilder.Entity<Contact>().Property(x => x.Address).HasMaxLength(200);
//            modelBuilder.Entity<Contact>().Property(x => x.SendedTime).IsRequired();
//            modelBuilder.Entity<Contact>().Property(x => x.IsDeleted).IsRequired();
//            modelBuilder.Entity<Contact>().Property(x => x.Status).IsRequired();
//            #endregion
//            //Category
//            #region Category
//            //modelBuilder.Entity<Category>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
//            modelBuilder.Entity<Category>().Property(x => x.ParentId);
//            modelBuilder.Entity<Category>().Property(x => x.Level).IsRequired();
//            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(450);
//            modelBuilder.Entity<Category>().Property(x => x.UrlSlug).IsRequired().HasMaxLength(450);
//            modelBuilder.Entity<Category>().Property(x => x.ImageUrl).HasMaxLength(250);
//            modelBuilder.Entity<Category>().Property(x => x.DateCreated).IsRequired();
//            modelBuilder.Entity<Category>().Property(x => x.Description);
//            modelBuilder.Entity<Category>().Property(x => x.IsPublished).IsRequired();
//            modelBuilder.Entity<Category>().Property(x => x.IsDeleted).IsRequired();
//            modelBuilder.Entity<Category>().Property(x => x.IsMainMenu).IsRequired();
//            modelBuilder.Entity<Category>().Property(x => x.Status).IsRequired();
//            modelBuilder.Entity<Category>().HasMany(x => x.Cards).WithOne(x => x.Category);
//            #endregion
//            //CategoryBlog   
//            #region CategoryBlog
            
//            //modelBuilder.Entity<CategoryBlog>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
//            modelBuilder.Entity<CategoryBlog>().Property(x => x.Title).IsRequired().HasMaxLength(250);
//            modelBuilder.Entity<CategoryBlog>().Property(x => x.Description).HasMaxLength(500);
//            modelBuilder.Entity<CategoryBlog>().Property(x => x.DateCreated).IsRequired();
//            modelBuilder.Entity<CategoryBlog>().Property(x => x.DateEdited).IsRequired();
//            modelBuilder.Entity<CategoryBlog>().Property(x => x.Status).IsRequired();
//            modelBuilder.Entity<CategoryBlog>().HasMany(x => x.Blogs).WithOne(x => x.CategoryBlog);
//            #endregion
//            //Error
//            #region Error
           
//            //modelBuilder.Entity<Error>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
//            modelBuilder.Entity<Error>().Property(x => x.Message).IsRequired().HasMaxLength(150);
//            modelBuilder.Entity<Error>().Property(x => x.DateCreated).IsRequired();
//            modelBuilder.Entity<Error>().Property(x => x.StackTrace).HasMaxLength(50);
//            #endregion
//#region Temple

//            // User
//            //#region User
//            //modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().UseSqlServerIdentityColumn();
//            //modelBuilder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(100);
//            //modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(200);
//            //modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(200);
//            //modelBuilder.Entity<User>().Property(u => u.Salt).IsRequired().HasMaxLength(200);
//            //#endregion
//            //// UserRole
//            //#region UserRole
//            //modelBuilder.Entity<UserRole>().Property(ur => ur.Id).IsRequired().UseSqlServerIdentityColumn();
//            //modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).IsRequired();
//            //modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).IsRequired();
//            //#endregion
//            //// Role
//            //#region Role
//            //modelBuilder.Entity<Role>().Property(r => r.Id).IsRequired().UseSqlServerIdentityColumn();
//            //modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(50);
//            //#endregion
//            #endregion
//        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Error> Errors { get; set; }
    }
}
