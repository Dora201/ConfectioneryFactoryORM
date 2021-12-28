namespace ConfectioneryFactory.Demo
{
    using System;
    using System.Linq;
    using ConfectioneryFactory.DataAccess;
    using ConfectioneryFactory.DataAccess.Repositories;
    using ConfectioneryFactory.Domain;


    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var ingredient1 = new Ingredient(1, "Мука", 70);
            var ingredient2 = new Ingredient(2, "Сахар", 40);
            var ingredient3 = new Ingredient(3, "Молоко", 100);
            var ingredient4 = new Ingredient(4, "Масло", 200);
            var product1 = new Product(1, "Сладкоежка", "Пончик", 100, ingredient1, ingredient2, ingredient4);
            var product2 = new Product(2, "Зима", "Эклер", 150, ingredient1, ingredient2, ingredient3);
            var product3 = new Product(3, "Карамель", "Леденец", 150);


            Console.WriteLine($"{product1}");
            Console.WriteLine($"{product2}");
            Console.WriteLine($"{product3}");

            var settings = new Settings();

            settings.AddDatabaseServer(@"DESKTOP-REIQ8I1\SQLEXPRESS");

            settings.AddDatabaseName("SecureConFactory");

            using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                session.Save(ingredient1);
                session.Save(ingredient2);
                session.Save(ingredient3);
                session.Save(ingredient4);

                session.Save(product1);
                session.Save(product2);
                session.Flush();
            }

            using (var session = sessionFactory.OpenSession())
            {
                var repoProduct = new ProductRepository();

                var repoIngredient = new IngredientRepository();
                Console.WriteLine("All ingredients");
                repoIngredient.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));
            }
        }
    }
}
