using Business.Abstarct;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDal _articleRepository;  
        public ArticleManager(IArticleDal articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IResult Create(Article entity)
        {
            _articleRepository.Create(entity);
          return new  SuccessResult(Messages.ProductAdded);
        }

        public void Delete(Article entity)
        {

            _articleRepository.Delete(entity);
        }

        public IDataResult<List<Article>> GetAll()
        {
            if( _articleRepository.GetAll().Count==0)
            {   
                return new ErrorDataResult<List<Article>>(Messages.ProductNotListed);
            }
            return new SuccessDataResult<List<Article>>(_articleRepository.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Article>> GetArticleByCategory(string name)
        {
            return new SuccessDataResult<List<Article>>(_articleRepository.GetArticleByCategory(name),"listeleme başarılı");
        }

        public IDataResult<ArticleDetailDto> GetArticleDetailDtos(string url)
        {
            return new SuccessDataResult<ArticleDetailDto>(_articleRepository.GetArticleDetailDtos(url), "başarılı");
        }

        public IDataResult<Article> GetArticleDetails(string url)
        {
            return new SuccessDataResult<Article>(_articleRepository.GetArticleDetails(url));
        }

        public IDataResult<Article> GetById(int id)
        {
            return new SuccessDataResult<Article>(_articleRepository.GetById(id));
        }

        public IDataResult<Article> GetbyIdWithCategories(int id)
        {
            return new SuccessDataResult<Article>(_articleRepository.GetbyIdWithCategories(id));
        }

        public int GetCountByCategory(string category)
        {
            return _articleRepository.GetCountByCategory(category);
        }

        public IDataResult<List<Article>> GetHomePageArticles()
        {
            return new SuccessDataResult<List<Article>>(_articleRepository.GetHomePageArticles());
        }

        public IDataResult<List<Article>> GetSearchResult(string searchString)
        {
            if (_articleRepository.GetSearchResult(searchString) == null)
            {
                return new ErrorDataResult<List<Article>>(Messages.ProductNotListed);
            }
            return new SuccessDataResult<List<Article>>(_articleRepository.GetSearchResult(searchString));
        }

        public void Update(Article entity)
        {
            _articleRepository.Update(entity);
        }

        public bool Update(Article entity, int[] categoryIds)
        {
                if(categoryIds.Length==0)
                {
                    return false;
                }
                _articleRepository.Update(entity, categoryIds);
                return true;
        }

    }
}
