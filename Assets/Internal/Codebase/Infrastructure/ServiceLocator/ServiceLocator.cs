using System;
using System.Collections.Generic;

namespace Internal.Codebase
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, IService> Services = new Dictionary<Type, IService>();

        public static void RegisterService<TService>(TService service) where TService : IService
        {
            if (!Services.TryAdd(typeof(TService), service))
                throw new InvalidOperationException($"Service {typeof(TService)} is already registered.");
        }

        public static IService GetService<T>() where T : IService
        {
            if (!Services.TryGetValue(typeof(T), out IService service))
                throw new InvalidOperationException($"Service {typeof(T)} not registered.");

            return service;
        }
    }
}

