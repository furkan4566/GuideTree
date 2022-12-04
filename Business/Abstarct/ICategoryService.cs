using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface ICategoryService
    {
        Category GetById(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByWithArticle(int categoryId);
        void DeleteFromCategory(int articleId, int categoryId);
    }
}
