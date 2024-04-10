using MongoDB.Driver;
using TiklaGelsinAPI.Domain.Entities;
using TiklaGelsinAPI.Application.Dto;
using MongoDB.Bson;

namespace TiklaGelsinAPI.Domain.Repositories
{
    public class ProductRepository : IProductrepository
    {
        private IMongoCollection<Product> productCollection;

        public ProductRepository()
        {
            var client = new MongoClient("mongodb://mongo:27017/");

            var database = client.GetDatabase("DevelopmentDB");

            productCollection = database.GetCollection<Product>("Product");

        }


        public Product InsertOne(Product product)
        {

            productCollection.InsertOne(product);

            return product;
        }


        public List<Product> InsertAll(List<Product> product)
        {


            productCollection.InsertMany(product);

            return product;

        }



        public Product getByID(string id)
        {

            var filteredItem = productCollection.Find(x =>x.Id == id && x.IsDeleted != true).FirstOrDefault();

            return filteredItem;

        }

        public List<Product> getAll()
        {

            var productList = productCollection.Find(new BsonDocument()).ToList();

            return productList;

        }

        public void Test(string a)
        {
            var b = 1;
        }
    }
}
