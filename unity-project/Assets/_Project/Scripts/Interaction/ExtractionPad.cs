using UnityEngine;
using SalvageCrew.Core;

namespace SalvageCrew.Interaction
{
    /// <summary>
    /// Trigger volume in the lander airlock. Counts crew currently on the pad.
    /// ContractManager checks this when player calls launch.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class ExtractionPad : MonoBehaviour
    {
        public int CrewOnPad { get; private set; }
        [SerializeField] private IntEventChannel onCrewOnPadChanged;

        private void Reset()
        {
            var c = GetComponent<Collider>();
            if (c) c.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            CrewOnPad++;
            onCrewOnPadChanged?.Raise(CrewOnPad);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            CrewOnPad = Mathf.Max(0, CrewOnPad - 1);
            onCrewOnPadChanged?.Raise(CrewOnPad);
        }
    }
}
