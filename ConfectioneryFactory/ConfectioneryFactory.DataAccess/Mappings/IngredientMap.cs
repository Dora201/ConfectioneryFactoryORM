using FluentNHibernate.Mapping;
using ConfectioneryFactory.Domain;

namespace ConfectioneryFactory.DataAccess.Mappings
{
    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Ingredient"/> на таблицу в БД и наоборот.
    /// </summary>
    class IngredientMap : ClassMap<Ingredient>
    {
        public IngredientMap()
        {
            this.Table("Ingredients");

            this.Id(x => x.Id);

            this.Map(x => x.Name)
                .Not.Nullable();

            this.Map(x => x.Price)
                .Not.Nullable();
        }
    }
}
