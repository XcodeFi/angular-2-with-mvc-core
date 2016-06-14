using GreetingCard.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GreetingCard.Infrastructure
{
    public class GreetingCardContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public GreetingCardContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            string schema = "dbo";
            //Card
            #region Card
            modelBuilder.Entity<Card>().ToTable(schema + ".Card");
            modelBuilder.Entity<Card>().HasKey(x => x.Id);

            modelBuilder.Entity<Card>().Property(x => x.CateId).HasColumnName("CateId").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Card>().Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Card>().Property(x => x.Title).HasColumnName("Title").IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            modelBuilder.Entity<Card>().Property(x => x.Content).HasColumnName("Content").HasColumnType("nvarchar").HasMaxLength(500);
            modelBuilder.Entity<Card>().Property(x => x.ViewNo).HasColumnName("ViewNo").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Card>().Property(x => x.LikesNo).HasColumnName("LikesNo").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Card>().Property(x => x.CardSize).HasColumnName("CardSize").HasColumnType("nvarchar").HasMaxLength(50);
            modelBuilder.Entity<Card>().Property(x => x.CardType).HasColumnName("CardType").HasColumnType("nvarchar").HasMaxLength(50);
            modelBuilder.Entity<Card>().Property(x => x.IsDelete).HasColumnName("IsDelete").IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Card>().Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasColumnType("nvarchar").HasMaxLength(250);
            modelBuilder.Entity<Card>().Property(x => x.RateNo).HasColumnName("RateNo").HasColumnType("tinyint");
            modelBuilder.Entity<Card>().Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Card>().Property(x => x.IsPublish).HasColumnName("IsPublish").IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Card>().Property(x => x.TextSearch).HasColumnName("TextSearch").HasColumnType("nvarchar").HasMaxLength(250);
            #endregion
            // Blog
            #region BLog
            modelBuilder.Entity<Blog>().ToTable(schema + ".Blog");
            modelBuilder.Entity<Blog>().HasKey(x => x.Id);

            modelBuilder.Entity<Blog>().Property(x => x.CateBlogId).HasColumnName("CateBlogId").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Blog>().Property(x => x.Title).HasColumnName("Title").IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            modelBuilder.Entity<Blog>().Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Blog>().Property(x => x.UrlSlug).HasColumnName("UrlSlug").HasColumnType("nvarchar").HasMaxLength(250);
            modelBuilder.Entity<Blog>().Property(x => x.Summary).HasColumnName("Summary").IsRequired().HasColumnType("nvarchar").HasMaxLength(300);
            modelBuilder.Entity<Blog>().Property(x => x.Content).HasColumnName("Content").IsRequired().HasColumnType("nvarchar");
            modelBuilder.Entity<Blog>().Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasColumnType("nvarchar").HasMaxLength(500);
            modelBuilder.Entity<Blog>().Property(x => x.ViewNo).HasColumnName("ViewNo").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Blog>().Property(x => x.IsDelete).HasColumnName("IsDelete").IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Blog>().Property(x => x.IsLock).HasColumnName("IsLock").IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Blog>().Property(x => x.Status).HasColumnName("Status").IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Blog>().Property(x => x.DatePosted).HasColumnName("DatePosted").IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Blog>().Property(x => x.LikeNo).HasColumnName("LikeNo").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Blog>().Property(x => x.DateEdited).HasColumnName("DateEdited").IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Blog>().Property(x => x.TextSearch).HasColumnName("TextSearch").HasColumnType("nvarchar").HasMaxLength(250);
            modelBuilder.Entity<Blog>().HasMany(x => x.Comments).WithOne(x => x.Blog);
            #endregion
            //Comment
            #region Comment
            modelBuilder.Entity<Comment>().ToTable(schema + ".Comment");
            modelBuilder.Entity<Comment>().HasKey(x => x.Id);

            modelBuilder.Entity<Comment>().Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Comment>().Property(x => x.Content).HasColumnName("Content").HasColumnType("nvarchar");
            modelBuilder.Entity<Comment>().Property(x => x.IsDelete).HasColumnName("IsDelete").IsRequired().HasColumnType("tinyint");
            modelBuilder.Entity<Comment>().Property(x => x.LikeNo).HasColumnName("LikeNo").HasColumnType("int");
            modelBuilder.Entity<Comment>().Property(x => x.Status).HasColumnName("Status").IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Comment>().Property(x => x.CardId).HasColumnName("CardId").HasColumnType("int");
            modelBuilder.Entity<Comment>().Property(x => x.DatePosted).HasColumnName("DatePosted").IsRequired().HasColumnType("datetime");
            #endregion
            //Contact
            #region Contact
            modelBuilder.Entity<Contact>().ToTable(schema + ".Contact");
            modelBuilder.Entity<Contact>().HasKey(x => x.Id);

            modelBuilder.Entity<Contact>().Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Contact>().Property(x => x.Title).HasColumnName("Title").HasColumnType("nvarchar").HasMaxLength(150);
            modelBuilder.Entity<Contact>().Property(x => x.Content).HasColumnName("Content").HasColumnType("nvarchar");
            modelBuilder.Entity<Contact>().Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50);
            modelBuilder.Entity<Contact>().Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(100);
            modelBuilder.Entity<Contact>().Property(x => x.Phone).HasColumnName("Phone").HasColumnType("nvarchar").HasMaxLength(20);
            modelBuilder.Entity<Contact>().Property(x => x.Address).HasColumnName("Address").HasColumnType("nvarchar").HasMaxLength(200);
            modelBuilder.Entity<Contact>().Property(x => x.SendedTime).HasColumnName("SendedTime").IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Contact>().Property(x => x.IsDelete).HasColumnName("IsDelete").IsRequired().HasColumnType("tinyint");
            modelBuilder.Entity<Contact>().Property(x => x.Status).HasColumnName("Status").IsRequired().HasColumnType("tinyint");
            #endregion
            //Category
            #region Category
            modelBuilder.Entity<Category>().ToTable(schema + ".Category");
            modelBuilder.Entity<Category>().HasKey(x => x.Id);

            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Category>().Property(x => x.ParentId).HasColumnName("Parent_Id").HasColumnType("int");
            modelBuilder.Entity<Category>().Property(x => x.Level).HasColumnName("Level").IsRequired().HasColumnType("tinyint");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
            modelBuilder.Entity<Category>().Property(x => x.UrlSlug).HasColumnName("UrlSlug").IsRequired().HasColumnType("varchar").HasMaxLength(450);
            modelBuilder.Entity<Category>().Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasColumnType("nvarchar").HasMaxLength(250);
            modelBuilder.Entity<Category>().Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar");
            modelBuilder.Entity<Category>().Property(x => x.IsPublish).HasColumnName("IsPublish").IsRequired().HasColumnType("tinyint");
            modelBuilder.Entity<Category>().Property(x => x.IsDelete).HasColumnName("IsDelete").IsRequired().HasColumnType("tinyint");
            modelBuilder.Entity<Category>().Property(x => x.IsMainMenu).HasColumnName("IsMainMenu").IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Category>().Property(x => x.Status).HasColumnName("Status").IsRequired().HasColumnType("tinyint");
            modelBuilder.Entity<Category>().HasMany(x => x.Cards).WithOne(x => x.Category);
            #endregion
            //CategoryBlog   
            #region CategoryBlog
            modelBuilder.Entity<CategoryBlog>().ToTable(schema + ".CategoryBlog");
            modelBuilder.Entity<CategoryBlog>().HasKey(x => x.Id);

            modelBuilder.Entity<CategoryBlog>().Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("int");
            modelBuilder.Entity<CategoryBlog>().Property(x => x.Title).HasColumnName("Title").IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            modelBuilder.Entity<CategoryBlog>().Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar").HasMaxLength(500);
            modelBuilder.Entity<CategoryBlog>().Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<CategoryBlog>().Property(x => x.DateEdited).HasColumnName("DateEdited").IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<CategoryBlog>().Property(x => x.Status).HasColumnName("Status").IsRequired().HasColumnType("bit");
            modelBuilder.Entity<CategoryBlog>().HasMany(x => x.Blogs).WithOne(x => x.CategoryBlog);
            #endregion
            //Error
            #region Error
            modelBuilder.Entity<Error>().ToTable(schema + ".Error");
            modelBuilder.Entity<Error>().HasKey(x => x.Id);

            modelBuilder.Entity<Error>().Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("int");
            modelBuilder.Entity<Error>().Property(x => x.Message).HasColumnName("Message").IsRequired().HasColumnType("nvarchar").HasMaxLength(150);
            modelBuilder.Entity<Error>().Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Error>().Property(x => x.StackTrace).HasColumnName("StackTrace").HasColumnType("nvarchar").HasMaxLength(50);
            #endregion
            // User
            #region User
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.Salt).IsRequired().HasMaxLength(200);
            #endregion
            // UserRole
            #region UserRole
            modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).IsRequired();
            modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).IsRequired();
            #endregion
            // Role
            #region Role
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(50);
            #endregion
        }
    }
}
