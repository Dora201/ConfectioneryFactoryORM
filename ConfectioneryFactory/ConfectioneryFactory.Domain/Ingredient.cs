using System;
using System.Collections.Generic;
using ConfectioneryFactory.Staff.Extensions;

namespace ConfectioneryFactory.Domain
{
    public class Ingredient
    {

        public Ingredient(int id, string name, int price)
        {
            this.Id = id;

            var trimmName = name.TrimOrNull();

            this.Name = trimmName ?? throw new ArgumentOutOfRangeException(nameof(name));
            this.Price = price;
        }

        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int Price { get; protected set; }

        public virtual HashSet<Product> Products { get; protected set; } = new HashSet<Product>();

        public virtual bool AddProduct(Product product)
        {
            return product == null ? throw new ArgumentNullException(nameof(product)) : this.Products.Add(product);
        }

        public override string ToString() => $"{Id}) {Name} - {Price}";
    }
}
