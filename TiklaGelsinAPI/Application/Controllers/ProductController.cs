using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using TiklaGelsinAPI.Application.Dto;
using TiklaGelsinAPI.Domain.Services;

namespace TiklaGelsinAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        //private IProductrepository _productRepository;
        private IProductService _productService;
        public ProductController(IProductService productService)
            {
            //_productRepository = productrepository;
            _productService = productService;

        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {

            //var result = _productRepository.getAll();

            try
            {
                var result = _productService.GetProducts();
                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                throw;
            }
            

            // return Ok(result);
        }

        //[HttpGet("GetProductByID")]
        [HttpGet("{id}")]
        public IActionResult GetProductByID(string id)
        {
        //    // _productRepository.InsertOne(filteredItem); ///////////////

            
        //    //var result = _productRepository.getByID(id);

            var result = _productService.GetProduct(id);

            return Ok(result);


        }
        // POST api/<ProductController>
        [HttpPost("CreateProduct")]
        public IActionResult PostByID([FromBody] CreateProductRequestDto Product)
        {

            
            var result = _productService.InsertProduct(Product);

            return Ok(result);


        }


        [HttpPost("CreateProducts")]
        public IActionResult PostAll([FromBody] List <ProductDto> ProductDtoList)
        {

            var result = _productService.InsertProducts(ProductDtoList);

            return Ok(result);




        }


    }


}
