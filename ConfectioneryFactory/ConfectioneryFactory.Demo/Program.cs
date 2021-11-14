﻿namespace ConfectioneryFactory.Demo
{
    using System;
    using System.Configuration;
    using System.Linq;

    using ConfectioneryFactory.Domain;

    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product(1, "Сладкоежка", "Пончик", 100, 2000);
            var ingredient = new Ingredient(1, "Мука", 70, 100);

            Console.WriteLine($"{product} {ingredient}");
        }
    }
}