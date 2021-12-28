namespace ConfectioneryFactory.DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using ConfectioneryFactory.Domain;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Product"/> на таблицу БД и наоборот.
    /// </summary>
    internal class ProductMap : ClassMap<Product>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ProductMap"/>.
        /// </summary>
        public ProductMap()
        {
            this.Table("Products");

            this.Id(x => x.Id);

            this.Map(x => x.Name)
                .Not.Nullable();

            this.Map(x => x.Type)
                .Not.Nullable();

            this.Map(x => x.Price)
                .Not.Nullable();

            this.HasManyToMany(x => x.Ingredients)
               .Cascade.Delete()
               .Inverse();
        }
    }
}
