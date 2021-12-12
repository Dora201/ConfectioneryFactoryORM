using NHibernate;
using NUnit.Framework;


namespace ConfectioneryFactory.DataAccess.Tests
{
    public class BaseMapTests
    {
        protected ISession Session { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Session = TestConfigurator.BuildSessionForTest();
        }

        [TearDown]
        public void TearDown()
        {
            this.Session?.Dispose();
        }
    }
}