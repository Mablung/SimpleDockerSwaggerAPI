using Microsoft.Extensions.Caching.StackExchangeRedis;
using MongoDB.Driver;
using TiklaGelsinAPI.Application.Dto;
using TiklaGelsinAPI.Domain.Entities;
using TiklaGelsinAPI.Domain.Repositories;

namespace TiklaGelsinAPI.Domain.Services
{
    public class RedisCacheService : ICacheManager
    {

        private RedisCacheOptions options;
        

       
        public RedisCacheService()
        {
           

        }

        
    }
}
