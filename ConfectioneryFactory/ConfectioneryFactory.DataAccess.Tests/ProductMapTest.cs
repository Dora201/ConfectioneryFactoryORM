using FluentNHibernate.Testing;
using ConfectioneryFactory.Domain;
using NUnit.Framework;

namespace ConfectioneryFactory.DataAccess.Tests
{
    [TestFixture]
    internal class ProductMapTest : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            var product = new Product(1, "Тестовое имя", "Тестовый тип", 100);

            new PersistenceSpecification<Product>(this.Session)
                .VerifyTheMappings(product);
        }
    }
}
