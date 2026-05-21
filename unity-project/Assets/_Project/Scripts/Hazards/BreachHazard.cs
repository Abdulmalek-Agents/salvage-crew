using UnityEngine;
using SalvageCrew.Data;
using SalvageCrew.Player;

namespace SalvageCrew.Hazards
{
    /// <summary>
    /// Hull breach: pulls crew toward this transform, applies O2 drain multiplier on overlapping crew.
    /// Can be toggled active/inactive (ValvePanel hook).
    /// </summary>
    public class BreachHazard : MonoBehaviour, IHazard
    {
        [SerializeField] private bool active = false;
        [SerializeField] private float effectRadius = 8f;
        [SerializeField] private LayerMask crewMask = ~0;
        [SerializeField] private GameObject vfxRoot;

        public bool IsActive => active;

        private void OnEnable() { HazardSystem.Instance?.Register(this); UpdateVfx(); }
        private void OnDisable() { HazardSystem.Instance?.Unregister(this); }

        public void SetActive(bool a)
        {
            active = a;
            UpdateVfx();
            Debug.Log($"[BreachHazard:{name}] active={a}");
        }

        private void UpdateVfx() { if (vfxRoot) vfxRoot.SetActive(active); }

        public void Tick(float dt, HazardProfile profile)
        {
            if (!active || !profile.breachEnabled) return;
            var hits = Physics.OverlapSphere(transform.position, effectRadius, crewMask, QueryTriggerInteraction.Ignore);
            foreach (var h in hits)
            {
                var crew = h.GetComponentInParent<CrewMember>();
                var o2 = h.GetComponentInParent<OxygenSystem>();
                if (crew != null)
                {
                    var pull = (transform.position - crew.transform.position).normalized * profile.breachPullForce;
                    crew.ApplyKnockForce(pull);
                }
                if (o2 != null) o2.DrainMultiplier = profile.breachO2DrainMultiplier;
            }
        }
    }
}
