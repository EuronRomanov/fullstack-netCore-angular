using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dto;
using server.Entities;
using server.Interface.Repository;

namespace server.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContex contex;
        public ProductRepository(DataContex contex) : base(contex)
        {
        this.contex=contex;
        }

        public async Task<Pagination<Product>> GetAllIncludingChildEntities(CatalogSpec inData)
        {

        IQueryable<Product> productQuery=contex.products.AsQueryable();

            if (!string.IsNullOrEmpty(inData.search))
            {
                 productQuery= productQuery.Where(p=>p.Name.Contains(inData.search));
            }

              if (inData.minPrice.HasValue)
            {
                 productQuery= productQuery.Where(p=>p.Price>=inData.minPrice);
            }


              if (inData.inStock.HasValue)
            {
                if (inData.inStock == true)
                {
                    productQuery= productQuery.Where(p=>p.StackQuantity>0);

                }
                else
                {
                    productQuery= productQuery.Where(p=>p.StackQuantity==0);

                }
            }

              if (inData.categoryId.HasValue)
            {
                 productQuery= productQuery.Where(p=>p.CategoryId==inData.categoryId);
            }
              if (inData.brandId.HasValue)
            {
                 productQuery= productQuery.Where(p=>p.BrandId==inData.brandId);
            }


            if(!string.IsNullOrEmpty(inData.sort))
            {
                if (inData.sort.ToLower() == "price")
                {
                    if (inData.sortOrder.ToLower() == "des")
                    {
                        productQuery=productQuery.OrderByDescending(p=>p.Price);
                    }
                    else
                    {
                        productQuery=productQuery.OrderBy(p=>p.Price);

                    }
                }
                if (inData.sort == "name")
                {
                     if (inData.sortOrder.ToLower() == "des")
                    {
                        productQuery=productQuery.OrderByDescending(p=>p.Name);
                    }
                    else
                    {
                        productQuery=productQuery.OrderBy(p=>p.Name);

                    }
                }


            }


return new Pagination<Product>()
{
    PageIndex=inData.pageIndex,
    PageSize=inData.pageSize,
    Count=await contex.products.CountAsync(),
    Data=await productQuery
            .Skip((inData.pageIndex-1)* inData.pageSize)
            .Take(inData.pageSize)
            .ToListAsync()
};

          /*  return await productQuery
            .Skip((inData.pageIndex-1)* inData.pageSize)
            .Take(inData.pageSize)
            .ToListAsync(); */
          /* return await contex.products
           .Include(p=>p.Brand)
           .Include(p=>p.Category)
           .Include(p=>p.Thumbnail)
           .ToListAsync();*/
        }
    }
}
