using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfectioneryFactory.Domain
{
    public class Product
    {
        public Product(int id, string name, string type, int price, int numOfProducts)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
            NumOfProducts = numOfProducts;
        }

        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Type { get; protected set; }
        public virtual int Price { get; protected set; }
        public virtual int NumOfProducts { get; protected set; }

        public override string ToString()
        {
            return $"{Id}) {Type} <<{Name}>> - {Price} (Всего: {NumOfProducts})";
        }
    }
}
