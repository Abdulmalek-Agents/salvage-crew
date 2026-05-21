using System.Collections.Generic;
using UnityEngine;
using SalvageCrew.Data;

namespace SalvageCrew.Hazards
{
    /// <summary>
    /// Authoritative on host. Holds a registry of active hazards and ticks them
    /// using the active HazardProfile + DifficultyProfile.
    /// </summary>
    public class HazardSystem : MonoBehaviour
    {
        public static HazardSystem Instance { get; private set; }

        [SerializeField] private HazardProfile activeProfile;
        [SerializeField] private DifficultyProfile difficulty;

        public HazardProfile Profile => activeProfile;
        public DifficultyProfile Difficulty => difficulty;

        private readonly List<IHazard> _hazards = new();

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
        }

        public void SetProfile(HazardProfile p, DifficultyProfile d)
        {
            activeProfile = p; difficulty = d;
        }

        public void Register(IHazard h) { if (!_hazards.Contains(h)) _hazards.Add(h); }
        public void Unregister(IHazard h) => _hazards.Remove(h);

        private void Update()
        {
            if (activeProfile == null) return;
            float dt = Time.deltaTime * (difficulty != null ? difficulty.hazardTickMultiplier : 1f);
            foreach (var h in _hazards) h.Tick(dt, activeProfile);
        }
    }

    public interface IHazard
    {
        void Tick(float dt, HazardProfile profile);
    }
}
