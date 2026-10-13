using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data;
using server.Entities;
using server.Interface.Repository;

namespace server.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        //private readonly DataContex contex;
        public ProductRepository(DataContex contex) : base(contex)
        {
            //this.contex=contex;
        }
    }
}
