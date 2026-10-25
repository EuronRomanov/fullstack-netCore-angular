using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Entities;
using server.Interface.Repository;
using server.Interface.Service;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
       // private readonly IProductRepository productRepository;                                                                                                                                                                                              

        private readonly ICatalogService catalogService;
        public CatalogController(ICatalogService catalogService)
        {
          //  this.productRepository=productRepository;
          this.catalogService=catalogService;
        }


        [HttpPost]
        [Route("product/getall")]
         public async Task<ActionResult<ResponseDto>> GetAllProducts(CatalogSpec req)
        {
            ResponseDto response=new ResponseDto();
            Pagination<Product>products=await catalogService.GetAllProducts(req);
            response.Data=products;
            return Ok(response);
        }
        
       /* [HttpGet]
         [Route("getAll")]
        public async Task<ActionResult<ResponseDto>> GetAllProducts()
        {
            ResponseDto response=new ResponseDto();
            IEnumerable<Product>products=await productRepository.GetAllAsync();
            response.Data=products;
            return Ok(response);
        }*/

       /* [HttpGet("{productId}")]
        public async Task<ActionResult<ResponseDto>> GetProductById(int productId)
        {
            ResponseDto response = new ResponseDto();
            Product? product = await productRepository.GetByIdAsync(productId);
        
            if (product == null)
            {
                response.IsSuccessed = false;
                response.Message = $"No product found with id {productId}";
                return NotFound(response);
            }
        
            response.Data = product;
            return Ok(response);
        }*/


       /* [HttpPost]
         [Route("create")]
        public async Task<ActionResult<ResponseDto>> CreateProducts(Product newProduct)
        {
               ResponseDto response = new ResponseDto();
                await productRepository.AddAsync(newProduct);
                response.Data = newProduct;
                response.Message = "Product created successfully";
                return Ok(response);
        }*/

          [HttpPost]
         [Route("product/create")]
        public async Task<ActionResult<ResponseDto>> CreateProducts(CreateProductReq newProduct)
        {
                 Product product=await catalogService.CreateProduct(newProduct);
                  ResponseDto response=new ResponseDto();
                   response.Data=product;
                return Ok(response);
        }


          /*[HttpPost]
           [Route("update")]
        public async Task<ActionResult<ResponseDto>> UpdateProducts(Product product)
        {
           ResponseDto response = new ResponseDto();
            await productRepository.UpdateAsync(product);
            response.Message = "Product updated successfully";
            return Ok(response);
        }*/


        /*[HttpDelete]
        [Route("delete/{productId}")]
        public async Task<ActionResult<ResponseDto>> DeleteProducts(int productId)
        {
            ResponseDto response=new ResponseDto();
            Product? product=await productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                response.IsSuccessed=false;
                response.Message=$"No product found with id {productId.ToString()}";
return BadRequest(response);
            }
           await productRepository.DeleteAsync(product);
            response.Message = $"Product with id {productId} deleted successfully";
          return Ok(response);
        }*/


        [HttpDelete]
        [Route("product/delete/{productId}")]
        public async Task<ActionResult<ResponseDto>> DeleteProducts(int productId)
        {
            ResponseDto response=new ResponseDto();
           await catalogService.DeleteProduct(productId);
           
          return Ok(response);
        }


        #region category api

        [HttpGet]
        [Route("category/getall")]
         public async Task<ActionResult<ResponseDto>> GetAllCategories()
        {
            ResponseDto response=new ResponseDto();
            IEnumerable<Category>categories=await catalogService.GetAllCategory();
            response.Data=categories;
            return Ok(response);
        }



          [HttpPost]
         [Route("category/create")]
        public async Task<ActionResult<ResponseDto>> CreateCategory(CreateCategoryReq newCategory)
        {
                Category category=await catalogService.CreateCategory(newCategory);
                ResponseDto response=new ResponseDto();
                  response.Data=category;
                return Ok(response);
        }


        
        [HttpDelete]
        [Route("category/delete/{categoryId}")]
        public async Task<ActionResult<ResponseDto>> DeleteCategory(int categoryId)
        {
            ResponseDto response=new ResponseDto();
           await catalogService.DeleteCategory(categoryId);           
          return Ok(response);
        }



        #endregion


 #region brand api

        [HttpGet]
        [Route("brand/getall")]
         public async Task<ActionResult<ResponseDto>> GetAllBrands()
        {
            ResponseDto response=new ResponseDto();
            IEnumerable<Brand>brands=await catalogService.GetAllBrand();
            response.Data=brands;
            return Ok(response);
        }



          [HttpPost]
         [Route("brand/create")]
        public async Task<ActionResult<ResponseDto>> CreateBrand(CreateBrandReq newBrand)
        {
                Brand brand=await catalogService.CreateBrand(newBrand);
                ResponseDto response=new ResponseDto();
                  response.Data=brand;
                return Ok(response);
        }


        
        [HttpDelete]
        [Route("brand/delete/{brandId}")]
        public async Task<ActionResult<ResponseDto>> DeleteBrand(int brandId)
        {
            ResponseDto response=new ResponseDto();
           await catalogService.DeleteBrand(brandId);           
          return Ok(response);
        }



        #endregion



    }
}
