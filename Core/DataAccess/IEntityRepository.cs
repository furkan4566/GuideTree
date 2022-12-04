using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        //Burayı ve efentityrepository kodlama.io 8.gün dersine göre degiştir
        TEntity GetById(int id);
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter=null);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
