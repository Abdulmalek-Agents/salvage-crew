using UnityEngine;
using SalvageCrew.Core;
using SalvageCrew.Data;

namespace SalvageCrew.Player
{
    public class OxygenSystem : MonoBehaviour
    {
        [SerializeField] private DifficultyProfile difficulty;
        [SerializeField] private float maxOxygen = 100f;
        [SerializeField] private float currentOxygen = 100f;
        [SerializeField] private FloatEventChannel onOxygenChanged;
        [SerializeField] private VoidEventChannel onCrewDown;

        public float Current => currentOxygen;
        public float Max => maxOxygen;

        public float DrainMultiplier { get; set; } = 1f;
        public bool InWreck { get; set; }

        public void SetCapacity(float cap)
        {
            maxOxygen = cap;
            currentOxygen = Mathf.Min(currentOxygen, maxOxygen);
        }

        public void Refill() { currentOxygen = maxOxygen; onOxygenChanged?.Raise(currentOxygen / maxOxygen); }

        private void Update()
        {
            if (!InWreck || difficulty == null) return;
            currentOxygen = Mathf.Max(0f, currentOxygen - difficulty.oxygenDrainPerSec * DrainMultiplier * Time.deltaTime);
            onOxygenChanged?.Raise(currentOxygen / maxOxygen);
            if (currentOxygen <= 0f)
            {
                onCrewDown?.Raise();
                InWreck = false;
                Debug.Log("[OxygenSystem] Crewmate incapacitated — O2 depleted.");
            }
        }
    }
}
