using UnityEngine;

namespace SalvageCrew.Data
{
    [CreateAssetMenu(menuName = "SalvageCrew/Hazard Profile", fileName = "Hazards_")]
    public class HazardProfile : ScriptableObject
    {
        [Header("Breach")]
        public bool breachEnabled = true;
        [Range(0f, 50f)] public float breachPullForce = 12f;
        [Range(0f, 10f)] public float breachO2DrainMultiplier = 3f;

        [Header("Low Gravity")]
        public bool lowGravEnabled = true;
        [Range(0f, 1f)] public float lowGravStrength = 0.25f;

        [Header("Fire (M2+)")]
        public bool fireEnabled = false;
        [Range(0f, 10f)] public float fireSpreadPerSec = 1f;

        [Header("Contagion (M3+)")]
        public bool contagionEnabled = false;
        [Range(0f, 10f)] public float contagionRatePerSec = 0.5f;

        [Header("Drones (M4+)")]
        public bool dronesEnabled = false;
        public int droneCount = 0;
    }
}
