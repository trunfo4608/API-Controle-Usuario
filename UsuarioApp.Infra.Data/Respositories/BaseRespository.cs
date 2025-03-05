using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Infra.Data.Data;

namespace UsuarioApp.Infra.Data.Respositories
{
    public class BaseRespository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class

    {
        public void Add(TEntity entity)
        {
            using(var dataContext =new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using(var dataContext =new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
