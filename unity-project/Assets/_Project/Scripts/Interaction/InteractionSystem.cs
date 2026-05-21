using UnityEngine;
using SalvageCrew.Player;

namespace SalvageCrew.Interaction
{
    public class InteractionSystem : MonoBehaviour
    {
        [SerializeField] private InputReader input;
        [SerializeField] private Transform rayOrigin;
        [SerializeField] private float range = 2.5f;
        [SerializeField] private float radius = 0.3f;
        [SerializeField] private LayerMask mask = ~0;

        public IInteractable Current { get; private set; }

        private void OnEnable()
        {
            if (input != null)
            {
                input.OnInteractPressed += DoInteract;
                input.OnPickDropPressed += DoPickDrop;
            }
        }
        private void OnDisable()
        {
            if (input != null)
            {
                input.OnInteractPressed -= DoInteract;
                input.OnPickDropPressed -= DoPickDrop;
            }
        }

        private void Update()
        {
            Current = null;
            if (rayOrigin == null) return;
            if (Physics.SphereCast(rayOrigin.position, radius, rayOrigin.forward, out var hit, range, mask))
                Current = hit.collider.GetComponentInParent<IInteractable>();
        }

        private void DoInteract() => Current?.Interact(this);
        private void DoPickDrop() { if (Current is IPickable p) p.PickOrDrop(this); }
    }

    public interface IInteractable { string Prompt { get; } void Interact(InteractionSystem source); }
    public interface IPickable     { void PickOrDrop(InteractionSystem source); }
}
