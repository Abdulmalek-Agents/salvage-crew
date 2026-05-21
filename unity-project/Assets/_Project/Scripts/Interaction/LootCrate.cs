using UnityEngine;
using SalvageCrew.Core;
using SalvageCrew.Data;
using SalvageCrew.Player;

namespace SalvageCrew.Interaction
{
    /// <summary>
    /// Pickable loot crate. Networking ownership is handled by the optional NetworkedInteractable
    /// sibling component (Mirror); this script remains net-agnostic so it works in solo mode too.
    /// </summary>
    public class LootCrate : MonoBehaviour, IInteractable, IPickable
    {
        [SerializeField] private LootItemData item;
        [SerializeField] private VoidEventChannel onCrateDelivered;
        [SerializeField] private Transform carryAnchor;

        public LootItemData Item => item;
        public string Prompt => $"Pick up {item.displayName}";
        public bool IsHeld { get; private set; }

        private Transform _holder;
        private Rigidbody _rb;

        private void Awake() { _rb = GetComponent<Rigidbody>(); }

        public void Interact(InteractionSystem src) => PickOrDrop(src);

        public void PickOrDrop(InteractionSystem src)
        {
            if (!IsHeld) Pickup(src);
            else Drop();
        }

        private void Pickup(InteractionSystem src)
        {
            var inv = src.GetComponentInParent<InventorySystem>();
            if (inv == null || !inv.TryAdd(item)) return;
            IsHeld = true;
            _holder = src.transform;
            if (_rb) { _rb.isKinematic = true; _rb.detectCollisions = false; }
            transform.SetParent(_holder);
            transform.localPosition = Vector3.forward * 0.5f + Vector3.down * 0.2f;
            transform.localRotation = Quaternion.identity;
        }

        private void Drop()
        {
            if (_holder != null)
            {
                var inv = _holder.GetComponentInParent<InventorySystem>();
                inv?.TryRemove(item);
            }
            IsHeld = false;
            transform.SetParent(null);
            if (_rb) { _rb.isKinematic = false; _rb.detectCollisions = true; }
            _holder = null;
        }

        public void NotifyDeliveredAndDestroy()
        {
            onCrateDelivered?.Raise();
            Destroy(gameObject);
        }
    }
}
