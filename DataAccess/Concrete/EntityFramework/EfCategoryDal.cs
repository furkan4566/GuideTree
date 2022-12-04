using DataAccess.Abstarct;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, GuideTreeContext>, ICategoryDal
    {
        public void DeleteFromCategory(int articleId, int categoryId)
        {
            using (var context = new GuideTreeContext())
            {
                var cmd = "delete  from ArticleCategory where ArticleId=@p0 and CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, articleId, categoryId);//geri dönüş degil sorgu çalıştırma
            }
        }

        public Category GetByWithArticle(int categoryId)
        {
            using (var context = new GuideTreeContext())
            {
                return context.Categories
                                         .Where(c => c.CategoryId == categoryId)
                                         .Include(a => a.ArticleCategories)
                                         .ThenInclude(a => a.Article).FirstOrDefault();
            }
        }
    }
}
