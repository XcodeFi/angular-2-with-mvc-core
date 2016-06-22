using GreetingCard.Entities;
using GreetingCard.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GreetingCard.Infrastructure
{
    public class SampleData
    {
        const string defaultAdminUserName = "DefaultAdminUserName";
        const string defaultAdminPassword = "DefaultAdminPassword";

        public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider, bool createUsers = true)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<GreetingCardContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    await InsertTestData(serviceProvider);
                    if (createUsers)
                    { 
                        await CreateAdminUser(serviceProvider);
                    }
                }
            }
        }
        private static async Task InsertTestData(IServiceProvider serviceProvider)
        {
            var cards = GetCard(Cates);

            await AddOrUpdateAsync(serviceProvider, cate => cate.Id, Cates.Select(cate => cate.Value));
            await AddOrUpdateAsync(serviceProvider, card => card.Id, cards);
        }

        // TODO [EF] This may be replaced by a first class mechanism in EF
        private static async Task AddOrUpdateAsync<TEntity>(
            IServiceProvider serviceProvider,
            Func<TEntity, object> propertyToMatch, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            // Query in a separate context so that we can attach existing entities as modified
            List<TEntity> existingData;
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<GreetingCardContext>();
                existingData = db.Set<TEntity>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<GreetingCardContext>();
                foreach (var item in entities)
                {
                    db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
                        ? EntityState.Modified
                        : EntityState.Added;
                }

                await db.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Creates a store manager user who can manage the inventory.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            var env = serviceProvider.GetService<IHostingEnvironment>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            //const string adminRole = "Administrator";

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            // TODO: Identity SQL does not support roles yet
            //var roleManager = serviceProvider.GetService<ApplicationRoleManager>();
            //if (!await roleManager.RoleExistsAsync(adminRole))
            //{
            //    await roleManager.CreateAsync(new IdentityRole(adminRole));
            //}

            var user = await userManager.FindByNameAsync(configuration[defaultAdminUserName]);
            if (user == null)
            {
                user = new ApplicationUser { UserName = configuration[defaultAdminUserName] };
                await userManager.CreateAsync(user, configuration[defaultAdminPassword]);
                //await userManager.AddToRoleAsync(user, adminRole);
                await userManager.AddClaimAsync(user, new Claim("Manager", "Allowed"));
            }

#if TESTING
            var envPerfLab = configuration["PERF_LAB"];
            if (envPerfLab == "true")
            {
                for (int i = 0; i < 100; ++i)
                {
                    var email = string.Format("User{0:D3}@example.com", i);
                    var normalUser = await userManager.FindByEmailAsync(email);
                    if (normalUser == null)
                    {
                        await userManager.CreateAsync(new ApplicationUser { UserName = email, Email = email }, "Password~!1");
                    }
                }
            }
#endif
        }

        private static Dictionary<string, Category> cates;
        public static Dictionary<string, Category> Cates
        {
            get
            {
                if (cates == null)
                {
                    var catesList = new Category[]
                    {
                        new Category {Name="Cate 1",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 2",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 3",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 4",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 5",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 56",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 7",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 8",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 9",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 10",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 111",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 112",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 13",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 14",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 15",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 16",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 17",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 18",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 19",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"},
                        new Category {Name="Cate 121",ImageUrl="~/imgs/cms/CROSSCARDS/15049-great-job.jpg",Description="No description description description description",UrlSlug="Na"}
                    };

                    cates = new Dictionary<string, Category>();

                    foreach (Category cate in catesList)
                    {
                        cates.Add(cate.Name, cate);
                    }
                }
                return cates;
            }
        }
        private static Card[] GetCard(Dictionary<string,Category> cates)
        {
            string cardSize = "100*100",content="content abc";
            string imageUrl = "~/imgs/cms/CROSSCARDS/15074-purrfect.jpg";
            string imageUrl2 = "~/imgs/cms/CROSSCARDS/15073-miss-you-kittens.jpg";
            string imageUrl3 = "~/imgs/cms/CROSSCARDS/15049-great-job.jpg";
            string textSearch = "text1, text2, text3";

            var cards = new Card[]
            {
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 4"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 1"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl2,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 2"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]},
                new Card{Content=content,ImageUrl=imageUrl3,CardSize=cardSize,TextSearch=textSearch,Category=cates["Cate 3"]}
            };

            foreach (var card in cards)
            {
                card.CateId = card.Category.Id;
            }

            return cards;
        }
    }
}
