using Loteria.Domain.Model;
using Loteria.Infra.Data.Base;
using Loteria.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Loteria.Infra.Data.Repository
{
    public class SorteioRepository : Repository<Sorteio>, ISorteioRepository
    {
        protected SorteioRepository()
        {

        }
        public SorteioRepository(IMemoryCache memoryCache) 
            : base(memoryCache, 
                  new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromDays(99999) },
                  "sorteio")
        {
        }
    }
}
