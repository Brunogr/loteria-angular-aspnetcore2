using Loteria.Domain.Model;
using Loteria.Infra.Data.Base;
using Loteria.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Loteria.Infra.Data.Repository
{
    public class CartelaRepository : Repository<Cartela>, ICartelaRepository
    {
        protected CartelaRepository()
        {

        }
        public CartelaRepository(IMemoryCache memoryCache) 
            : base(memoryCache, 
                  new MemoryCacheEntryOptions(), 
                  "cartela")
        {
        }
    }
}
