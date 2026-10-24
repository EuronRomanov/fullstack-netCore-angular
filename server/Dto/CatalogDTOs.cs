using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dto
{
    public class CreateProductReq
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int  StackQuantity{ get; set; }
        public bool InFeatured { get; set; }=false;
        public int CategoryId { get; set; }

        public int BrandId { get; set; }
        public IFormFile Thumbnail { get; set; }


    }


    public class CreateBrandReq
    {
         public string Name { get; set; }
        public IFormFile Image { get; set; }

    }

     public class CreateCategoryReq
    {
          public string Name { get; set; }
        public IFormFile Image { get; set; }
    }


    public class CatalogSpec
    {
        public int pageIndex {get; set;}=1;
        public int pageSize {get; set;}=10;
         public int? brandId {get; set;}
        public int? categoryId {get; set;}
        public string? search{get; set;}
        public bool? inStock {get; set;}
        public decimal? minPrice {get; set;}
        public decimal? maxPrice {get; set;}
        public string? sort {get; set;}

        public string sortOrder {get; set;}="asc";


    }
}