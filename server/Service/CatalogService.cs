using server.Interface.Repository;
using server.Interface.Service;

namespace server.Service
{
    public class CatalogService:ICatalogService
    {


           private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IBrandRepository brandRepository;
        private readonly ImageService imageService;

        public CatalogService(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            ImageService imageService)
        {
            this.productRepository = productRepository;
            this.categoryRepository =categoryRepository;
            this.brandRepository = brandRepository;
            this.imageService=imageService;
        }  
    }
}
