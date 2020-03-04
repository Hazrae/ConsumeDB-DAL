using System;
using System.Collections.Generic;
using System.Text;

namespace DalDBSlide.Repository
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetOne(int id);
        void Create(TEntity t);
        void Delete(int id);
        void Update(TEntity t);
    }
}
