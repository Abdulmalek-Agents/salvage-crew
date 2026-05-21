using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SalvageCrew.Data
{
    public enum ContractType { Salvage, Rescue, Quarantine, BlackBox, Hybrid }

    [CreateAssetMenu(menuName = "SalvageCrew/Contract Data", fileName = "Contract_")]
    public class ContractData : ScriptableObject
    {
        public string contractId;
        public string displayName;
        [TextArea] public string briefing;
        public ContractType type;

        public WreckData wreck;
        public HazardProfile hazardProfile;
        public DifficultyProfile difficulty;

        [Header("Salvage Type")]
        public int requiredCrates = 5;

        [Header("Reward / Limits")]
        public int payoutScrip = 500;
        public float departureWindowSec = 1800f;
        public int finalCountdownSec = 300;
    }
}
