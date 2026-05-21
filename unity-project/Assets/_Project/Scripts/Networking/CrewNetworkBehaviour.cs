using UnityEngine;
using SalvageCrew.Player;

namespace SalvageCrew.Networking
{
    /// <summary>
    /// Optional sibling component that toggles local authority on a CrewMember and disables input
    /// for remote clones.
    /// </summary>
#if MIRROR
    [Mirror.RequireComponent(typeof(Mirror.NetworkIdentity))]
    public class CrewNetworkBehaviour : Mirror.NetworkBehaviour
    {
        [SerializeField] private CrewMember crewMember;
        [SerializeField] private GameObject[] disableForRemote;

        public override void OnStartLocalPlayer()
        {
            if (crewMember != null) crewMember.IsLocalAuthority = true;
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
            if (!isLocalPlayer)
            {
                if (crewMember != null) crewMember.IsLocalAuthority = false;
                foreach (var g in disableForRemote) if (g) g.SetActive(false);
            }
        }
    }
#else
    public class CrewNetworkBehaviour : MonoBehaviour
    {
        // Stub when Mirror not installed (solo lobby).
    }
#endif
}
