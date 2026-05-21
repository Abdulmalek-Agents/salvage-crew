using UnityEngine;

namespace SalvageCrew.Networking
{
    /// <summary>
    /// Network bootstrap.
    /// Compiles in a no-op form before Mirror is installed (so the project opens cleanly on first clone).
    /// Once Mirror is added (see docs/07_Setup_Instructions.md §4.1) it becomes a Mirror.NetworkManager subclass.
    /// </summary>
#if MIRROR
    public class NetworkManager_Salvage : Mirror.NetworkManager
    {
        public static NetworkManager_Salvage Instance { get; private set; }

        public override void Awake()
        {
            base.Awake();
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void StartHostingCoop()
        {
            StartHost();
            Debug.Log("[Net] Hosting (Mirror) started.");
        }

        public void JoinCoop(string address)
        {
            networkAddress = string.IsNullOrEmpty(address) ? networkAddress : address;
            StartClient();
            Debug.Log($"[Net] Joining {networkAddress}");
        }
    }
#else
    public class NetworkManager_Salvage : MonoBehaviour
    {
        public static NetworkManager_Salvage Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.LogWarning("[Net] Mirror not installed — NetworkManager_Salvage in stub mode. " +
                             "Solo lobby works. Install Mirror to enable co-op.");
        }

        public void StartHostingCoop()
        {
            Debug.LogWarning("[Net] StartHostingCoop() requires Mirror — falling back to solo.");
        }

        public void JoinCoop(string address)
        {
            Debug.LogWarning("[Net] JoinCoop() requires Mirror.");
        }
    }
#endif
}
