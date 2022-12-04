using DataAccess.Abstarct;
using Entities;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article, GuideTreeContext>, IArticleDal
    {
        public List<Article> GetArticleByCategory(string name)
        {
            using (var context = new GuideTreeContext())
            {
                var articles = context.Articles.AsQueryable();//kriter eklemeye yarıyor tolist yapılsaydı kriter bir işe yaramzdı
                if (!string.IsNullOrEmpty(name))//Bir deger gelmiş ise
                {
                    articles = articles.Include(i => i.ArticleCategories)//ınclude,thenınclude referans ulaşmak 
                                               .ThenInclude(i => i.Category)
                                               .Where(i => i.ArticleCategories.Any(a => a.Category.Url == name));//where şart eklemek
                }
                return articles.ToList();

            }
        }

        public Article GetbyIdWithCategories(int id)
        {
            using (var context = new GuideTreeContext())
            {
                return context.Articles
                                         .Where(i => i.ArticleId == id)
                                         .Include(i => i.ArticleCategories)
                                         .ThenInclude(i => i.Category).FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new GuideTreeContext())
            {//sorgu yapmak için öncellikle yapıcalak tabloya ulaşulması lazım 
                var articles = context.Articles.AsQueryable();//kriter eklemeye yarıyor tolist yapılsaydı kriter bir işe yaramzdı
                if (!string.IsNullOrEmpty(category))//Bir deger gelmiş ise
                {
                    articles = articles.Include(i => i.ArticleCategories)//ınclude,thenınclude referans ulaşmak 
                                               .ThenInclude(i => i.Category)
                                               .Where(i => i.ArticleCategories.Any(a => a.Category.Url == category));//where şart eklemek
                }
                return articles.Count();

            }
        }

        public Article GetArticleDetails(string url)
        {
            using (var context = new GuideTreeContext())
            {
                return context.Articles
                     .Where(i => i.Url == url)//burdaki parametre url'si articledeki url ile eşitleniuyor cs cshtml sayfasında article.url görünce baglantı saglanıyor
                     .Include(i => i.ArticleCategories)
                     .ThenInclude(i => i.Category).FirstOrDefault();
            }
        }

        public List<Article> GetHomePageArticles()//Ana sayfaya gelicek olan makaleleri belirler
        {
            using (var context = new GuideTreeContext())
            {
                return context.Articles.Where(i => i.IsHome == true).ToList();
            }
        }

        public List<Article> GetSearchResult(string searchString)
        {
            using (var context = new GuideTreeContext())
            {//sorgu yapmak için öncellikle yapıcalak tabloya ulaşulması lazım 
                var articles = context.Articles.Where(i => i.Title.ToLower().Contains(searchString.ToLower())).AsQueryable();//kriter eklemeye yarıyor tolist yapılsaydı kriter bir işe yaramzdı
                return articles.ToList();
            }
        }

        public void Update(Article entity, int[] categoryIds)
        {
            using (var context = new GuideTreeContext())
            {
                var articles = context.Articles
                                                  .Include(i => i.ArticleCategories)
                                                  .FirstOrDefault(i => i.ArticleId == entity.ArticleId);

                if (articles != null)
                {
                    articles.Title = entity.Title;
                    articles.Url = entity.Url;
                    articles.Description = entity.Description;
                    articles.IsHome = entity.IsHome;
                    articles.ImageUrl = entity.ImageUrl;
                    articles.ArticleCategories = categoryIds.Select(catid => new ArticleCategory()
                    {
                        ArticleId = entity.ArticleId,
                        CategoryId = catid
                    }).ToList();
                }
                context.SaveChanges();
            }
        }

        public ArticleDetailDto GetArticleDetailDtos(string url)
        {
            using (var context=new GuideTreeContext())
            {
                var result = from a in context.Articles
                             join c in context.Categories
                             on a.CategoryId equals c.CategoryId
                             select new ArticleDetailDto()
                             {
                                 ArticleId = a.ArticleId,
                                 ArticleTitle = a.Title,
                                 ArticleDescription = a.Description,
                                 ArticleImageUrl = a.ImageUrl,
                                 CategoryName = c.Name,
                                 CategoryUrl = c.Url
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
