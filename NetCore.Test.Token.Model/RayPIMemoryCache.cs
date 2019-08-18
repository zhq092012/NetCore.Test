using System;
using Microsoft.Extensions.Caching.Memory;

namespace NetCore.Test.Token.Model
{
    public class RayPIMemoryCache
    {
        public static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            object cached;
            return _cache.TryGetValue(key, out cached);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            if (key==null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.Get(key);
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresSliding"></param>
        /// <param name="expiressAbsoulte"></param>
        /// <returns></returns>
        public static bool AddMemoryCache(string key,object value,TimeSpan expiresSliding,TimeSpan expiressAbsoulte)
        {
            if (key==null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value==null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _cache.Set(key, value, new MemoryCacheEntryOptions().SetSlidingExpiration(expiresSliding).SetAbsoluteExpiration(expiressAbsoulte));
            return Exists(key);
        }
    }
}
