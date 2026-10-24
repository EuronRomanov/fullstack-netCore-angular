using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dto;
using server.Entities;

namespace server.Interface.Repository
{
    public interface IProductRepository:IGenericRepository<Product>
    {
                Task<Pagination<Product>> GetAllIncludingChildEntities(CatalogSpec inData);

    }
}