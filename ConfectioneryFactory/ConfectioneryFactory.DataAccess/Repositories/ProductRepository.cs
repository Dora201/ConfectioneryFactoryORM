namespace ConfectioneryFactory.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using ConfectioneryFactory.DataAccess.Repositories.Abstraction;
    using ConfectioneryFactory.Domain;
    using NHibernate;

    public class ProductRepository : IRepository<Product>
    {
        public Product Get(ISession session, int id) =>
            session?.Get<Product>(id);

        public Product Find(ISession session, Expression<Func<Product, bool>> predicate)
        {
            return this.GetAll(session).FirstOrDefault(predicate);
        }

        public IQueryable<Product> GetAll(ISession session) =>
            session?.Query<Product>();

        public IQueryable<Product> Filter(ISession session, Expression<Func<Product, bool>> predicate)
        {
            return this.GetAll(session).Where(predicate);
        }

        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ingredient> IngredientsWithoutCollaborates(ISession session)
        {
            return this.Filter(
                session,
                b => b.Ingredients.Count < 2)
                .SelectMany(b => b.Ingredients)
                    .Distinct();
        }

        public bool Save(Product entity, ISession session)
        {
            try
            {
                session?.Save(entity);
                session?.Flush();
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
