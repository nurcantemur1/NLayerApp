using NLayer.Core.Entity;

namespace NLayer.Core.Entity
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public ProductFeature Feature { get; set; }

    }
}
