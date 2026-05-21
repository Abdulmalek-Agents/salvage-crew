using System.Collections.Generic;
using UnityEngine;
using SalvageCrew.Data;

namespace SalvageCrew.Player
{
    public class InventorySystem : MonoBehaviour
    {
        [SerializeField] private int slotCount = 2;
        private readonly List<LootItemData> _items = new();

        public int SlotCount => slotCount;
        public IReadOnlyList<LootItemData> Items => _items;

        public bool TryAdd(LootItemData item)
        {
            if (_items.Count >= slotCount) return false;
            _items.Add(item);
            Debug.Log($"[Inventory] +{item.displayName} ({_items.Count}/{slotCount})");
            return true;
        }

        public bool TryRemove(LootItemData item) => _items.Remove(item);

        public void SetSlots(int n) => slotCount = Mathf.Max(1, n);
    }
}
