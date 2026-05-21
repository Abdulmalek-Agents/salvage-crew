using System;
using UnityEngine;

namespace SalvageCrew.Core
{
    [CreateAssetMenu(menuName = "SalvageCrew/Events/Void", fileName = "VoidEvent_")]
    public class VoidEventChannel : ScriptableObject
    {
        public event Action OnRaised;
        public void Raise() => OnRaised?.Invoke();
    }

    [CreateAssetMenu(menuName = "SalvageCrew/Events/String", fileName = "StringEvent_")]
    public class StringEventChannel : ScriptableObject
    {
        public event Action<string> OnRaised;
        public void Raise(string s) => OnRaised?.Invoke(s);
    }

    [CreateAssetMenu(menuName = "SalvageCrew/Events/Float", fileName = "FloatEvent_")]
    public class FloatEventChannel : ScriptableObject
    {
        public event Action<float> OnRaised;
        public void Raise(float v) => OnRaised?.Invoke(v);
    }

    [CreateAssetMenu(menuName = "SalvageCrew/Events/Int", fileName = "IntEvent_")]
    public class IntEventChannel : ScriptableObject
    {
        public event Action<int> OnRaised;
        public void Raise(int v) => OnRaised?.Invoke(v);
    }
}
