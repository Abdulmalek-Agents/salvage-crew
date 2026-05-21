using UnityEngine;

namespace SalvageCrew.Data
{
    [CreateAssetMenu(menuName = "SalvageCrew/Loot Item Data", fileName = "Loot_")]
    public class LootItemData : ScriptableObject
    {
        public string itemId;
        public string displayName;
        [Range(0f, 50f)] public float weightKg = 5f;
        public int scripValue = 100;
        [Range(1, 4)] public int slotSize = 1;
    }
}
