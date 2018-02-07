using Loteria.Core.Domain.Model.Base;
using Loteria.Infra.Data.Base;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loteria.Infra.Data.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        private IMemoryCache _memoryCache;
        private MemoryCacheEntryOptions _memoryOptions;
        private string _key;

        protected Repository()
        {

        }

        public Repository(IMemoryCache memoryCache, MemoryCacheEntryOptions memoryOptions, string key)
        {
            _memoryCache = memoryCache;
            _memoryOptions = memoryOptions;
            _key = key;
        }

        public virtual bool Delete(int id)
        {
            var items = new List<TEntity>();
            if (_memoryCache.TryGetValue(_key, out items))
            {
                var item = items.FirstOrDefault(p => p.Id == id);
                var removed = items.Remove(item);

                _memoryCache.Set(_key, items);
                return removed;
            }

            return false;
        }

        public virtual TEntity Get(int id)
        {
            var items = new List<TEntity>();
            if (_memoryCache.TryGetValue(_key, out items))
            {
                var item = items.FirstOrDefault(i => i.Id == id);

                return item;
            }

            return null;
        }

        public virtual IList<TEntity> GetAll()
        {
            var items = new List<TEntity>();
            if (_memoryCache.TryGetValue(_key, out items))
                return items;
            else
                return new List<TEntity>();
        }

        public virtual IList<TEntity> GetByFilter(Func<TEntity, bool> filter)
        {
            var items = new List<TEntity>();
            if (_memoryCache.TryGetValue(_key, out items))
            {
                return items.Where(filter).ToList();
            }
            else
                return new List<TEntity>();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            var items = _memoryCache.Get<List<TEntity>>(_key);

            if (items == null)
                items = new List<TEntity>();

            items.Add(entity);

            _memoryCache.Set(_key, items, _memoryOptions);

            return entity;
        }
    }
}
