
using TiklaGelsinAPI.Domain.Entities;


namespace TiklaGelsinAPI.Domain.Repositories
{
    public interface IProductrepository
    {
        void Test(string a);
        Product InsertOne(Product product);
        List<Product> InsertAll(List<Product> product);
        Product getByID(string id);
        List<Product> getAll();
    }
}
