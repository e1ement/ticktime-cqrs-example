using System;

namespace TickTime.Core.Entities
{
    public class ProductItem : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ProductItem(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
