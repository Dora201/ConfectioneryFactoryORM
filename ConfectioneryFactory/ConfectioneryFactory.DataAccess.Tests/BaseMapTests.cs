namespace ConfectioneryFactory.DataAccess.Tests
{
    using NHibernate;
    using NUnit.Framework;

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