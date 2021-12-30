namespace ConfectioneryFactory.DataAccess.Tests.Repositories
{
    using ConfectioneryFactory.DataAccess.Repositories;
    using ConfectioneryFactory.Domain;
    using NHibernate;
    using NUnit.Framework;
    
    [TestFixture]
    public class ProductRepositoryTests
    {
        [Test]
        public void Get_ValidId_Success()
        {
            var targetId = 1;

            using var session = GetSession();

            PrepareProductInStorage(session, targetId);

            var repository = GetRepository();

            var result = repository.Get(session, targetId);

            Assert.IsNotNull(result);
            Assert.AreEqual(targetId, result.Id);
        }

        private static void PrepareProductInStorage(ISession session, int targetId)
        {
            var product = new Product(1, "Тестовое название", "Тестовый тип", 100);

            session.Save(product);
            session.Flush();
            session.Clear();
        }

        private static ProductRepository GetRepository() => new ProductRepository();

        private static ISession GetSession() => TestConfigurator.BuildSessionForTest(showSql: true);
    }
}
