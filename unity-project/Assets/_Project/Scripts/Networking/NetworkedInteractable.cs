using UnityEngine;

namespace SalvageCrew.Networking
{
    /// <summary>
    /// Compiles in a no-op form before Mirror is imported. Once Mirror is present this becomes
    /// a NetworkBehaviour that mediates pickup/drop ownership via Commands and ClientRpcs.
    /// </summary>
#if MIRROR
    [Mirror.RequireComponent(typeof(Mirror.NetworkIdentity))]
    public class NetworkedInteractable : Mirror.NetworkBehaviour
    {
        [Mirror.SyncVar(hook = nameof(OnHolderChanged))]
        private uint holderNetId;

        public bool IsHeld => holderNetId != 0;

        public void RequestPickup() => CmdPickup(Mirror.NetworkClient.connection.identity.netId);
        public void RequestDrop()   => CmdDrop();

        [Mirror.Command(requiresAuthority = false)]
        private void CmdPickup(uint requester, Mirror.NetworkConnectionToClient sender = null)
        {
            if (holderNetId != 0) return;
            holderNetId = requester;
        }

        [Mirror.Command(requiresAuthority = false)]
        private void CmdDrop(Mirror.NetworkConnectionToClient sender = null)
        {
            if (sender == null || sender.identity == null) return;
            if (holderNetId != sender.identity.netId) return;
            holderNetId = 0;
        }

        private void OnHolderChanged(uint _, uint newHolder)
        {
            // Hook visuals/physics in here; LootCrate.cs handles local representation.
        }
    }
#else
    public class NetworkedInteractable : MonoBehaviour
    {
        public bool IsHeld { get; private set; }
        public void RequestPickup() { IsHeld = true; }
        public void RequestDrop()   { IsHeld = false; }
    }
#endif
}
