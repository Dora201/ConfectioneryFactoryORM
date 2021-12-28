namespace ConfectioneryFactory.DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using ConfectioneryFactory.Domain;

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

            this.HasManyToMany(x => x.Products)
                .Cascade.Delete();
        }
    }
}
