using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public static class SeedDatabase
    {
        //Test verisi eklenir,yeni bir database oluştugunda test yapılacak olan veriler eklenir ki her seferinde el ile eklenmesin
        //startup IsDevelopment  metodunda çalıştırılır
        public static void Seed()
        {
            var context = new GuideTreeContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }
                if (context.Articles.Count() == 0)
                {
                    context.Articles.AddRange(Articles);
                    context.AddRange(ArticleCategories);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories ={
                new Category(){Name="Web",Url="web"},
                new Category(){Name="Mobil",Url="mobil"},
                new Category(){Name="Oyun",Url="oyun" },
                new Category(){Name="Siber Güvenlik",Url="siber-güvenlik"}
         };
        private static Article[] Articles ={
                new Article(){Title="Front-and nedir",Description="açıklama",ImageUrl="Resim1"},
                new Article(){Title="Back-and nedir",Description="açıklama2",ImageUrl="Resim2"},
                new Article(){Title="Mobil geliştirme nedir",Description="açıklama3",ImageUrl="Resim3"},
                new Article(){Title="Oyun Tasarım nedir",Description="açıklama4",ImageUrl="Resim4"}
         };

        private static ArticleCategory[] ArticleCategories =
        {
            new ArticleCategory(){Article=Articles[0],Category=Categories[0]},
            new ArticleCategory(){Article=Articles[1],Category=Categories[0]},
            new ArticleCategory(){Article=Articles[2],Category=Categories[1]},
            new ArticleCategory(){Article=Articles[3],Category=Categories[2]},
        };
    }
}
