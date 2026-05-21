using UnityEngine;

namespace SalvageCrew.Data
{
    public enum UpgradeEffect
    {
        OxygenCapacity,
        InventorySlots,
        MagBoots,
        ScannerRange,
        HullIntegrity,
        FuelEfficiency
    }

    [CreateAssetMenu(menuName = "SalvageCrew/Ship Upgrade", fileName = "Upgrade_")]
    public class ShipUpgradeData : ScriptableObject
    {
        public string upgradeId;
        public string displayName;
        [TextArea] public string description;
        public UpgradeEffect effect;
        public float effectValue;
        public int costScrip = 500;
    }
}
