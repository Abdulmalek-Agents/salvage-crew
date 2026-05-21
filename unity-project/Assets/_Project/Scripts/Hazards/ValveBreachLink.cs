using UnityEngine;
using SalvageCrew.Core;

namespace SalvageCrew.Hazards
{
    /// <summary>
    /// Listens for valve toggles and toggles BreachHazard accordingly.
    /// Place on a GameObject in the scene, wire valve channel + breaches.
    /// </summary>
    public class ValveBreachLink : MonoBehaviour
    {
        [SerializeField] private StringEventChannel onValveToggled;
        [SerializeField] private string valveIdToWatch;
        [SerializeField] private BreachHazard[] breaches;
        [SerializeField] private bool openValveActivatesBreach = true;

        private void OnEnable() { if (onValveToggled != null) onValveToggled.OnRaised += Handle; }
        private void OnDisable() { if (onValveToggled != null) onValveToggled.OnRaised -= Handle; }

        private void Handle(string payload)
        {
            var parts = payload.Split(':');
            if (parts.Length != 2 || parts[0] != valveIdToWatch) return;
            bool open = parts[1] == "Open";
            bool active = openValveActivatesBreach ? open : !open;
            foreach (var b in breaches) if (b) b.SetActive(active);
        }
    }
}
