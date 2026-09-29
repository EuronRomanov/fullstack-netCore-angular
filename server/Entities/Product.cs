using System.ComponentModel;

namespace server.Entities
{
    public class Product:AuditBaseEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int  StackQuantity{ get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
        public bool InStock { get; set; }
        public bool InFeatured { get; set; }=false
        public int CategoryId { get; set; }

        public Category Category{ get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<ProductReview> ProductReviews { get; set; }





    }
}
