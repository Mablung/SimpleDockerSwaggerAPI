using TiklaGelsinAPI.Application.Dto;

namespace TiklaGelsinAPI.Domain.Services
{
    public interface IProductService
    {
        List<ProductDto> InsertProducts(List<ProductDto> productDtoList);
        ProductDto InsertProduct(CreateProductRequestDto productRequestDto);
        ProductDto GetProduct(string id);
        List<ProductDto> GetProducts();
    }
}
