using System;
using System.Collections.Generic;
using System.Linq;
using ConfectioneryFactory.Staff.Extensions;

namespace ConfectioneryFactory.Domain
{
    public class Product
    {
        public Product(int id, string name, string type, int price, params Ingredient[] ingredients)
            : this(id, name, type, price, new HashSet<Ingredient>(ingredients))
        {
        }

        public Product(int id, string name, string type, int price, HashSet<Ingredient> ingredients)
        {
            this.Id = id;

            var trimmName = name.TrimOrNull();
            var trimmType = type.TrimOrNull();

            this.Name = trimmName ?? throw new ArgumentOutOfRangeException(nameof(name));
            this.Type = trimmType ?? throw new ArgumentOutOfRangeException(nameof(type));
            this.Price = price;

            foreach (var ingredient in ingredients ?? Enumerable.Empty<Ingredient>())
                this.Ingredients.Add(ingredient);
        }

        [Obsolete("For ORM", true)]

        protected Product()
        { 
        }

        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Type { get; protected set; }
        public virtual int Price { get; protected set; }

        public virtual HashSet<Ingredient> Ingredients { get; protected set; } = new HashSet<Ingredient>();

        public override string ToString() => $"{Id}) {Type} <<{Name}>> - {Price}";
    }
}
