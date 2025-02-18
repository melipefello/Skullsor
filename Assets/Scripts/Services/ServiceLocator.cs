using System;
using System.Collections.Generic;

namespace Services
{
    public class ServiceLocator
    {
        readonly Dictionary<Type, object> _services = new();
        public T Get<T>() => (T) _services[typeof(T)];
        public void Register<T>(T service) => _services[typeof(T)] = service;
    }
}