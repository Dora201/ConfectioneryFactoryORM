namespace ConfectioneryFactory.Demo
{
    using System;
    using System.Configuration;
    using System.Linq;

    using ConfectioneryFactory.Domain;
    using ConfectioneryFactory.DataAccess;

    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var ingredient = new Ingredient(1, "Мука", 70);
            var product = new Product(1, "Сладкоежка", "Пончик", 100, ingredient);
            

            Console.WriteLine($"{product} \t {ingredient}");

            var settings = new Settings();

            settings.AddDatabaseServer(@"DESKTOP-REIQ8I1\SQLEXPRESS");

            settings.AddDatabaseName("ConfectioneryFactory");

            using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                session.Save(product);
                session.Save(ingredient);
                session.Flush();
            }

            using (var session = sessionFactory.OpenSession())
            {
                var tmpProduct = session.Query<Product>().First();

                Console.WriteLine(tmpProduct);
            }

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Clear();
                    var persistentIngredient = session.Load<Ingredient>(1);
                    var newProduct = persistentIngredient.Products.FirstOrDefault();
                    if (newProduct is null)
                    {
                        throw new ArgumentNullException(nameof(newProduct));
                    }

                    var persistentProduct = session.Get<Product>(newProduct.Id);
                    session.Delete(persistentProduct);
                    transaction.Commit();
                }

                session.Flush();
            }
        }
    }
}
