using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.DTOs;
using Entities.Entity;

namespace DataAccess.Abstarct
{
    public interface IArticleDal:IEntityRepository<Article>
   {
        Article GetArticleDetails(string url);
        ArticleDetailDto GetArticleDetailDtos(string url);
        List<Article> GetArticleByCategory(string name);

       List<Article> GetSearchResult(string searchString);
       List<Article> GetHomePageArticles();
        int GetCountByCategory(string category);
        Article GetbyIdWithCategories(int id);
        void Update(Article entity, int[] categoryIds);
    }
}
