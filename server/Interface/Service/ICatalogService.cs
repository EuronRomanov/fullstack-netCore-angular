using server.Dto;
using server.Entities;

namespace server.Interface.Service
{
    public interface ICatalogService
    {

        //Product
        Task<Pagination<Product>> GetAllProducts(CatalogSpec inData);
        Task<Product>CreateProduct(CreateProductReq inData);
        Task DeleteProduct(int productId);

        //Brand

          Task<IEnumerable<Brand>> GetAllBrand();
        Task<Brand>CreateBrand(CreateBrandReq inData);
        Task DeleteBrand(int brandId);

        //Category
  Task<IEnumerable<Category>> GetAllCategory();
        Task<Category>CreateCategory(CreateCategoryReq inData);
        Task DeleteCategory(int categorytId);

    }
}
