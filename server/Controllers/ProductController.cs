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
            return Ok(products);
        }


        [HttpPost]
         [Route("create")]
        public async Task<ActionResult<ResponseDto>> CreateProducts(Product newProduct)
        {
           await productRepository.AddAsync(newProduct);
            return Created();
        }


          [HttpPost]
           [Route("update")]
        public async Task<ActionResult<ResponseDto>> UpdateProducts(Product Product)
        {
           await productRepository.UpdateAsync(Product);
            return Ok();
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
            return Ok(response);
        }

    }
}
