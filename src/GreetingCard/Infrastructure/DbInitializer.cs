using GreetingCard.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreetingCard.Infrastructure
{
    public class DbInitializer
    {
        private static GreetingCardContext context;
        public static void Initialize(IServiceProvider serviceProvider, string imagesPath)
        {
            context = (GreetingCardContext)serviceProvider.GetService(typeof(GreetingCardContext));

            InitializeUserRoles();
            InitializeCard(imagesPath);

        }

        private static void InitializeCard(string imagesPath)
        {
            if (!context.Categories.Any())
            {
                #region Catgory
                List<Category> _categories = new List<Category>() {
                    new Category
                    {
                        ImageUrl = "https://ak.imgag.com/imgag/product/siteassets/general/3397604/ximage.jpg.pagespeed.ic.idflA36SvK.webp",
                        DateCreated = DateTime.UtcNow,
                        Description = "Anniversary Ecards",
                        Level = 1,
                        IsPublish = 1,
                        IsDelete = 0,
                        Name = "Anniversary Ecards",
                        UrlSlug = "anniversary_ecards",
                        IsMainMenu = true,
                        Status = 1,
                        ParentId = 1,
                    },
                    new Category
                    {
                        ImageUrl = "https://ak.imgag.com/imgag/product/siteassets/general/3397604/ximage.jpg.pagespeed.ic.idflA36SvK.webp",
                        DateCreated = DateTime.UtcNow,
                        Description = "Anniversary Ecards",
                        Level = 1,
                        IsPublish = 1,
                        IsDelete = 0,
                        Name = "Anniversary Ecards",
                        UrlSlug = "anniversary_ecards",
                        IsMainMenu = true,
                        Status = 1,
                        ParentId = 1,
                    },
                    new Category
                    {
                        ImageUrl = "https://ak.imgag.com/imgag/product/siteassets/general/3397604/ximage.jpg.pagespeed.ic.idflA36SvK.webp",
                        DateCreated = DateTime.UtcNow,
                        Description = "Anniversary Ecards",
                        Level = 1,
                        IsPublish = 1,
                        IsDelete = 0,
                        Name = "Anniversary Ecards",
                        UrlSlug = "anniversary_ecards",
                        IsMainMenu = true,
                        Status = 1,
                        ParentId = 1,
                    },
                    new Category
                    {
                        ImageUrl = "https://ak.imgag.com/imgag/product/siteassets/general/3397604/ximage.jpg.pagespeed.ic.idflA36SvK.webp",
                        DateCreated = DateTime.UtcNow,
                        Description = "Anniversary Ecards",
                        Level = 1,
                        IsPublish = 1,
                        IsDelete = 0,
                        Name = "Anniversary Ecards",
                        UrlSlug = "anniversary_ecards",
                        IsMainMenu = true,
                        Status = 1,
                        ParentId = 1,
                    }
                    };
                #endregion
                #region Card
                List<Card> _cards = new List<Card>() {
                    new Card
                    {
                        CardSize="100*100",
                        CardType="Image",
                        Content="Sinh nhat",
                        DateCreated=DateTime.UtcNow,
                        IsDelete=false,
                        ViewNo=0,
                        ImageUrl="",
                        IsPublish=true,
                        LikesNo=0,
                        RateNo=3,
                        Title="Sinh nhat",
                        UserId=1,
                        CateId=1,
                        TextSearch="abc,acb"
                    },
                    new Card
                    {
                        CardSize="100*100",
                        CardType="Image",
                        Content="Sinh nhat",
                        DateCreated=DateTime.UtcNow,
                        IsDelete=false,
                        ViewNo=0,
                        ImageUrl="",
                        IsPublish=true,
                        LikesNo=0,
                        RateNo=3,
                        Title="Sinh nhat",
                        UserId=1,
                        CateId=1,
                        TextSearch="abc,acb"
                    },
                    new Card
                    {
                        CardSize="100*100",
                        CardType="Image",
                        Content="Sinh nhat",
                        DateCreated=DateTime.UtcNow,
                        IsDelete=false,
                        ViewNo=0,
                        ImageUrl="",
                        IsPublish=true,
                        LikesNo=0,
                        RateNo=3,
                        Title="Sinh nhat",
                        UserId=1,
                        CateId=1,
                        TextSearch="abc,acb"
                    },
                    new Card
                    {
                        CardSize="100*100",
                        CardType="Image",
                        Content="Sinh nhat",
                        DateCreated=DateTime.UtcNow,
                        IsDelete=false,
                        ViewNo=0,
                        ImageUrl="",
                        IsPublish=true,
                        LikesNo=0,
                        RateNo=3,
                        Title="Sinh nhat",
                        UserId=1,
                        CateId=1,
                        TextSearch="abc,acb"
                    },
                    new Card
                    {
                        CardSize="100*100",
                        CardType="Image",
                        Content="Sinh nhat",
                        DateCreated=DateTime.UtcNow,
                        IsDelete=false,
                        ViewNo=0,
                        ImageUrl="",
                        IsPublish=true,
                        LikesNo=0,
                        RateNo=3,
                        Title="Sinh nhat",
                        UserId=1,
                        CateId=1,
                        TextSearch="abc,acb"
                    }

                };
                #endregion,
                #region Blog
                List<Blog> _blogs = new List<Blog>()
                {
                    new Blog
                    {
                        CateBlogId=1,
                        TextSearch="abc,acb",
                        UserId=1,
                        Title="test blog",
                        Content="test",
                        DateEdited=DateTime.UtcNow,
                        DatePosted=DateTime.UtcNow,
                        ImageUrl="test_blog",
                        UrlSlug="test_blog",
                        IsDelete=false,
                        IsLock=false,
                        Status=false,
                        Summary="test",
                        LikeNo=1,
                        ViewNo=1
                    }
                };

                #endregion
                #region 

                #endregion
            }
            context.SaveChanges();
        }


        private static void InitializeUserRoles()
        {
            if (!context.Roles.Any())
            {
                // create roles
                context.Roles.AddRange(new Role[]
                {
                new Role()
                {
                    Name="Admin"
                }
                });

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new User()
                {
                    Email = "chsakells.blog@gmail.com",
                    Username = "chsakell",
                    Password = "9wsmLgYM5Gu4zA/BSpxK2GIBEWzqMPKs8wl2WDBzH/4=",
                    Salt = "GTtKxJA6xJuj3ifJtTXn9Q==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                });

                // create user-admin for chsakell
                context.UserRoles.AddRange(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1  // chsakell
                }
            });
                context.SaveChanges();
            }
        }
    }
}
