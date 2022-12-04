using Core.DataAccess;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstarct
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        Category GetByWithArticle(int categoryId);
        void DeleteFromCategory(int articleId,int categoryId);
    }
}
