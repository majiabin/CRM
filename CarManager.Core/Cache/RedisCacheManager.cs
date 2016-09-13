﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Config;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CarManager.Core.Cache
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly string redisConectionString;
        public volatile ConnectionMultiplexer redisConnection;
        private readonly object redisConnectionLock = new object();


        public RedisCacheManager(ApplicationConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.RedisCacheConfig.ConnectionString))
            {
                throw new ArgumentException("redis config is empty", nameof(config));
            }
            this.redisConectionString = config.RedisCacheConfig.ConnectionString;
            this.redisConnection = GetRedisConnection();
        }

        private ConnectionMultiplexer GetRedisConnection()
        {
            if (this.redisConnection != null && redisConnection.IsConnected)
            {
                return redisConnection;
            }
            lock (redisConnectionLock)
            {
                if (this.redisConnection != null)
                {
                    redisConnection.Dispose();
                }
                this.redisConnection = ConnectionMultiplexer.Connect(redisConectionString);
            }
            return this.redisConnection;
        }

        public void Clear()
        {
            foreach (var endPonit in this.GetRedisConnection().GetEndPoints())
            {
                var server = this.GetRedisConnection().GetServer(endPonit);
                foreach (var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }

        public bool Contains(string key)
        {
            return redisConnection.GetDatabase().KeyExists(key);
        }

        public T Get<T>(string key)
        {
            var value = redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                return DeSerialize<T>(value);
            }
            else
            {
                return default(T);
            }
        }

        private T DeSerialize<T>(byte[] value)
        {
            if (value == null)
            {
                return default(T);
            }
            var jsonString = Encoding.UTF8.GetString(value);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        private byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public void Remove(string key)
        {
            redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value != null)
            {
                redisConnection.GetDatabase().StringSet(key, Serialize(value), cacheTime);
            }
        }
    }
}
