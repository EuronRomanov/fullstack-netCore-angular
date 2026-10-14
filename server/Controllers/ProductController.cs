using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Entities;
using server.Interface.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository=productRepository;
        }
        [HttpGet]
         [Route("getAll")]
        public async Task<ActionResult<ResponseDto>> GetAllProducts()
        {
            ResponseDto response=new ResponseDto();
            IEnumerable<Product>products=await productRepository.GetAllAsync();
            response.Data=products;
            return Ok(response);
        }

        [HttpGet("{productId}")]
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
        }


        [HttpPost]
         [Route("create")]
        public async Task<ActionResult<ResponseDto>> CreateProducts(Product newProduct)
        {
               ResponseDto response = new ResponseDto();
                await productRepository.AddAsync(newProduct);
                response.Data = newProduct;
                response.Message = "Product created successfully";
                return Ok(response);
        }


          [HttpPost]
           [Route("update")]
        public async Task<ActionResult<ResponseDto>> UpdateProducts(Product product)
        {
           ResponseDto response = new ResponseDto();
            await productRepository.UpdateAsync(product);
            response.Message = "Product updated successfully";
            return Ok(response);
        }


        [HttpDelete]
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
        }

    }
}
