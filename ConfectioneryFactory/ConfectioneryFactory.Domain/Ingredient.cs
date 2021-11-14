using System;
using System.Collections.Generic;
using System.Text;

namespace ConfectioneryFactory.Domain
{
    public class Ingredient
    {
        public Ingredient(int id, string name, int price, int numOfIngredients)
        {
            Id = id;
            Name = name;
            Price = price;
            NumOfIngredients = numOfIngredients;
        }

        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int Price { get; protected set; }
        public virtual int NumOfIngredients { get; protected set; }

        public override string ToString()
        {
            return $"{Id}) {Name} - {Price} (Всего: {NumOfIngredients})";
        }
    }
}
