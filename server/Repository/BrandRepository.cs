using server.Data;
using server.Entities;
using server.Interface.Repository;

namespace server.Repository
{
    public class BrandRepository:GenericRepository<Brand>,IBrandRepository
    {

        private readonly DataContex contex;

        public BrandRepository(DataContex contex) : base(contex) {
            this.contex = contex;

        }
    }
}
