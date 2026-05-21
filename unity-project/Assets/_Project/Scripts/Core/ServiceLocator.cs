using System;
using System.Collections.Generic;
using UnityEngine;

namespace SalvageCrew.Core
{
    public static class Services
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service) where T : class
        {
            if (_services.ContainsKey(typeof(T)))
                Debug.LogWarning($"[Services] {typeof(T).Name} already registered — overwriting.");
            _services[typeof(T)] = service;
        }

        public static T Get<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var s)) return (T)s;
            Debug.LogError($"[Services] {typeof(T).Name} not registered.");
            return null;
        }

        public static bool TryGet<T>(out T s) where T : class
        {
            if (_services.TryGetValue(typeof(T), out var x)) { s = (T)x; return true; }
            s = null; return false;
        }
    }
}
