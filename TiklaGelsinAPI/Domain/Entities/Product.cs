using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TiklaGelsinAPI.Domain.Entities
{
    public class Product
    {

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? ListelenmeTarihi { get; set; }
        public string TitleEng { get; set; }

        public string? Title { get; set; }
        public string? Body { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
