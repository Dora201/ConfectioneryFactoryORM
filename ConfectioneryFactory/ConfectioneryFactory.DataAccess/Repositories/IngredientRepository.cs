namespace ConfectioneryFactory.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConfectioneryFactory.DataAccess.Repositories.Abstraction;
    using ConfectioneryFactory.Domain;
    using NHibernate;

    public class IngredientRepository : IRepository<Ingredient>
    {
        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ingredient> Filter(ISession session, System.Linq.Expressions.Expression<Func<Ingredient, bool>> predicate)
        {
            return this.GetAll(session)
                .Where(predicate);
        }

        public Ingredient Find(ISession session, System.Linq.Expressions.Expression<Func<Ingredient, bool>> predicate)
        {
            return this.GetAll(session)
                .FirstOrDefault(predicate);
        }

        public Ingredient Get(ISession session, int id) =>
            session?.Get<Ingredient>(id);

        public IQueryable<Ingredient> GetAll(ISession session) =>
            session?.Query<Ingredient>();

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }

        public bool Save(Ingredient entity, ISession session)
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
