using Core.Utilities.Results;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface IArticleService
    {
        IDataResult<Article> GetById(int id);
        IDataResult<Article> GetArticleDetails(string url);
        IDataResult<ArticleDetailDto> GetArticleDetailDtos(string url);
        IDataResult<List<Article>> GetSearchResult(string searchString);
        IDataResult<List<Article>> GetArticleByCategory(string name);
        IDataResult<List<Article>> GetAll();
        IResult Create(Article entity);
        bool Update(Article entity, int[] categoryIds);
        void Delete(Article entity);
        IDataResult<List<Article>> GetHomePageArticles();
        int GetCountByCategory(string category);
        IDataResult<Article> GetbyIdWithCategories(int id);
        
    }
}
