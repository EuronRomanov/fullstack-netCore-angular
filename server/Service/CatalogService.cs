using AutoMapper;
using server.Dto;
using server.Entities;
using server.Interface.Repository;
using server.Interface.Service;
using server.Repository;

namespace server.Service
{
    public class CatalogService:ICatalogService
    {


        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IImageService imageService;

        private readonly IMapper mapper;

        public CatalogService(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IImageService imageService,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository =categoryRepository;
            this.brandRepository = brandRepository;
            this.imageService=imageService;
            this.mapper=mapper;
        }

        public async Task<Product> CreateProduct(CreateProductReq inData)
        {
            Category? category=await this.categoryRepository.GetByIdAsync(inData.CategoryId);
            Brand? brand=await this.brandRepository.GetByIdAsync(inData.BrandId);

            if(category==null){throw new Exception($"Invalid Category Id {inData.CategoryId}");};
           if(brand==null){throw new Exception($"Invalid Brand Id {inData.BrandId}");};
           Image image =await this.imageService.SaveImageAsync(inData.Thumbnail);

           Product newProduct=mapper.Map<Product>(inData);

           newProduct.Brand=brand;
           newProduct.Category=category;
           newProduct.Thumbnail=image;

           return await this.productRepository.AddAsync(newProduct);

        }

        public async Task<Brand> CreateBrand(CreateBrandReq inData)
        {
             Image image =await this.imageService.SaveImageAsync(inData.Image);
             Brand brand=mapper.Map<Brand>(inData);
             brand.Image=image;
             return await brandRepository.AddAsync(brand);
        }

        public async Task<Category> CreateCategory(CreateCategoryReq inData)
        { 
             Image image =await this.imageService.SaveImageAsync(inData.Image);
             Category category=mapper.Map<Category>(inData);
             category.Image=image;
             return await categoryRepository.AddAsync(category);
        }

        public async Task DeleteBrand(int brandId)
        {
            Brand? brand=await this.brandRepository.GetByIdAsync(brandId);
            if(brand==null){throw new Exception($"Invalid Brand Id ${brandId}");};

            //await imageService.DeleteImageAsync(brand.ImageId);
            if (brand.ImageId > 0)
            {
                await imageService.DeleteImageAsync(brand.ImageId);
            }
            await brandRepository.DeleteAsync(brand);

        }

       public async  Task DeleteCategory(int categorytId)
        {
            Category? category=await this.categoryRepository.GetByIdAsync(categorytId);
             if(category==null){throw new Exception($"Invalid Category Id {categorytId}");};
 
  if (category.ImageId > 0)
{
     await imageService.DeleteImageAsync(category.ImageId);
}
            await categoryRepository.DeleteAsync(category);
        }

       public async Task DeleteProduct(int productId)
        {
           Product? product=await this.productRepository.GetByIdAsync(productId);
             if(product==null){throw new Exception($"Invalid Product Id {productId}");};
            await imageService.DeleteImageAsync(product.ThumbnailId);
            await productRepository.DeleteAsync(product);
        }

       public async  Task<IEnumerable<Brand>> GetAllBrand()
        {
           return await brandRepository.GetAllIncludingImage();
        }

       public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await categoryRepository.GetAllIncludingImage();
        }

        public async Task<Pagination<Product>> GetAllProducts(CatalogSpec inData)
        {
            return await  productRepository.GetAllIncludingChildEntities(inData);
        }
    }
}
