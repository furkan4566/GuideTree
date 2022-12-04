using Business.Abstarct;
using DataAccess.Abstarct;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryRepository;
        public CategoryManager(ICategoryDal categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }

        public string ErrorMassage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public void DeleteFromCategory(int articleId, int categoryId)
        {
            _categoryRepository.DeleteFromCategory(articleId,categoryId);
        }

        public List<Category> GetAll()
        {
            
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByWithArticle(int categoryId)
        {
           return  _categoryRepository.GetByWithArticle(categoryId);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }

        public bool Validation(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
