using MongoDB.Driver;
using TiklaGelsinAPI.Application.Dto;
using TiklaGelsinAPI.Domain.Entities;
using TiklaGelsinAPI.Domain.Repositories;

namespace TiklaGelsinAPI.Domain.Services
{
    public class ProductService : IProductService
    {

        private IProductrepository _productRepository;
        private IMongoCollection<Product> productCollection;
        public ProductService(IProductrepository productrepository)
        {
            _productRepository = productrepository;

        }

        public List<ProductDto> GetProducts()
        {
            //var filteredItem = productCollection.Find(x => x.Id == id).FirstOrDefault();


            var result = _productRepository.getAll();

            //başka bir apiya call atıcak ve priceı çekecek

            var productList = result.Select(x => new ProductDto()
            {
                Id = x.Id,
                Body = x.Body,
                Title = x.Title,
                Price = 1.0
                
            }).ToList();

            return productList;

          

        }


        public ProductDto GetProduct(string id)
        {
            //var filteredItem = productCollection.Find(x => x.Id == id).FirstOrDefault();
            // 1-) 

            var result = _productRepository.getByID(id);

            var product = new ProductDto()
            {
                Id = result.Id,
                Body = result.Body,
                Title = result.Title,
                //CreatedAt = DateTime.Now
            };

            return product;

        }



        public ProductDto InsertProduct(CreateProductRequestDto productRequestDto)
        {
            var product = new Product()
            {
                Body = productRequestDto.Body,
                Title = productRequestDto.Title,
                CreatedAt = DateTime.Now 
            };


            var result = _productRepository.InsertOne(product);

            var productDto = new ProductDto()
            {
                Id = result.Id,
                Body = result.Body,
                Title = result.Title,
                //CreatedAt = DateTime.Now
            };

            return productDto;

        }


        public List<ProductDto> InsertProducts(List<ProductDto> productDtoList)
        {
            var productList = productDtoList.Select(x => new Product()
            {
                Id = x.Id,
                Body = x.Body,
                Title = x.Title,
                CreatedAt = DateTime.Now
            }).ToList();


            var result = _productRepository.InsertAll(productList);

            return productDtoList;

        }
    }
}
