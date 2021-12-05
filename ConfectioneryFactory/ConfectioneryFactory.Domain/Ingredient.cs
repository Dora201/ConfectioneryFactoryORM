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

        [Obsolete("For ORM", true)]

        protected Ingredient()
        {
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Ingredient)obj);
        }

        /// <inheritdoc cref="IEquatable{T}">
        public virtual bool Equals(Ingredient other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Id == other.Id;
        }
    }
}
