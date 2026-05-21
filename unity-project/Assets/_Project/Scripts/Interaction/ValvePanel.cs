using UnityEngine;
using SalvageCrew.Core;

namespace SalvageCrew.Interaction
{
    /// <summary>
    /// Two-state valve (Open / Sealed). Raises an event when toggled.
    /// Hook BreachHazard to react to the channel.
    /// </summary>
    public class ValvePanel : MonoBehaviour, IInteractable
    {
        public enum State { Sealed, Open }

        [SerializeField] private string valveId;
        [SerializeField] private State state = State.Open;
        [SerializeField] private StringEventChannel onValveToggled; // raises valveId+":"+state

        public string Prompt => state == State.Open ? "Seal valve" : "Open valve";

        public void Interact(InteractionSystem src)
        {
            state = state == State.Open ? State.Sealed : State.Open;
            onValveToggled?.Raise($"{valveId}:{state}");
            Debug.Log($"[ValvePanel:{valveId}] → {state}");
        }
    }
}
