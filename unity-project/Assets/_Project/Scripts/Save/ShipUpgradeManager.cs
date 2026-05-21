using System.Collections.Generic;
using UnityEngine;
using SalvageCrew.Core;
using SalvageCrew.Data;
using SalvageCrew.Player;

namespace SalvageCrew.Save
{
    /// <summary>
    /// Reads owned upgrades from SaveSystem.Profile and applies them to crew members.
    /// </summary>
    public class ShipUpgradeManager : MonoBehaviour, IService
    {
        [SerializeField] private List<ShipUpgradeData> allUpgrades = new();
        public void Register() => Services.Register(this);

        public void ApplyTo(CrewMember crew, OxygenSystem o2, InventorySystem inv)
        {
            var save = Services.Get<SaveSystem>();
            if (save == null) return;
            foreach (var u in allUpgrades)
            {
                if (u == null || !save.OwnsUpgrade(u.upgradeId)) continue;
                Apply(u, crew, o2, inv);
            }
        }

        public bool TryPurchase(ShipUpgradeData upgrade)
        {
            var save = Services.Get<SaveSystem>();
            if (save == null) return false;
            if (save.OwnsUpgrade(upgrade.upgradeId)) return false;
            if (save.Profile.scrip < upgrade.costScrip) return false;
            save.Profile.scrip -= upgrade.costScrip;
            save.GrantUpgrade(upgrade.upgradeId);
            return true;
        }

        private void Apply(ShipUpgradeData u, CrewMember crew, OxygenSystem o2, InventorySystem inv)
        {
            switch (u.effect)
            {
                case UpgradeEffect.OxygenCapacity: o2.SetCapacity(o2.Max + u.effectValue); break;
                case UpgradeEffect.InventorySlots: inv.SetSlots(inv.SlotCount + Mathf.RoundToInt(u.effectValue)); break;
                case UpgradeEffect.MagBoots: crew.MagBootsEnabled = true; break;
                // Additional effects mapped here in M2+
            }
        }
    }
}
