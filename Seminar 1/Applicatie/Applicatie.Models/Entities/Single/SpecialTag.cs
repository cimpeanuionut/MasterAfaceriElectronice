using System.Collections.Generic;

namespace MagazinOnline.Models.Entities
{
    public partial class SpecialTag : IEntity<int>
    {
        public SpecialTag()
        {
            ProductsSpecialTags = new HashSet<ProductsSpecialTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductsSpecialTag> ProductsSpecialTags { get; set; }
    }
}
