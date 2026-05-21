using UnityEngine;
using SalvageCrew.Player;

namespace SalvageCrew.Hazards
{
    [RequireComponent(typeof(Collider))]
    public class LowGravityZone : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier = 1.2f;

        private void Reset() { var c = GetComponent<Collider>(); if (c) c.isTrigger = true; }

        private void OnTriggerEnter(Collider other)
        {
            var crew = other.GetComponentInParent<CrewMember>();
            if (crew == null) return;
            if (!crew.MagBootsEnabled) crew.MoveSpeedMultiplier = speedMultiplier;
        }

        private void OnTriggerExit(Collider other)
        {
            var crew = other.GetComponentInParent<CrewMember>();
            if (crew == null) return;
            crew.MoveSpeedMultiplier = 1f;
        }
    }
}
